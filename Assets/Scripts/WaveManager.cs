using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    List<Wave> Waves = new List<Wave>();

    public Rigidbody2D Ball;

    public float ZeroLevel;
    public float LeftBorder;
    public float RightBorder;
    
    public float center;
    [SerializeField]
    float _BaseWidth;
    [SerializeField]
    float _BaseAmplitude;
    [SerializeField]
    float _BaseDecreasePerSecond;
    [SerializeField]
    float _BaseSpreadSpeed;

    [SerializeField]
    float _PushForce;


    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddWave(center);
        }

        UpdateWaves();

        Vector2 ballPosition = Ball.transform.position;
        if (ballPosition.y < SampleAllWavesAt(Ball.transform.position.x))
        {
            float[] xValues;
            float[] yValues = GetSamples(LeftBorder, RightBorder, 500, out xValues);
            
            float minDist = float.MaxValue;
            int minIndex = 0;
            for (int i = 0; i < yValues.Length; i++)
            {
                float distance = Vector2.Distance(ballPosition, new Vector2(xValues[i], yValues[i]));
                if(distance < minDist)
                {
                    minDist = distance;
                    minIndex = i;
                }
            }

            Ball.AddForce(_PushForce * (new Vector2(xValues[minIndex], yValues[minIndex]) - ballPosition) / minDist);
            
        }

    }

    private void UpdateWaves()
    {
        List<Wave> cachedForDeletion = new List<Wave>();
        foreach (Wave wave in Waves)
        {
            //actual update
            wave.Update();

            //delete depricated waves
            if (wave.Amplitude <= 0)
            {
                cachedForDeletion.Add(wave);
            }
        }
        foreach (Wave waveToBeDeleted in cachedForDeletion)
        {
            Waves.Remove(waveToBeDeleted);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="center">center of the newly created wave</param>
    /// <param name="widthFactor">modifier for the width of a wave. Multiplies the baseWidth of a Wave with widthFactor</param>
    /// <param name="amplitudeFactor">modifier for the amplitude of a wave. Multiplies the baseAmplitude of a Wave with amplitudeFactor</param>
    /// <param name="decreasePerSecondFactor">modifier for the decreasePerSecond of a wave. Multiplies the baseDecreasePerSecond of a Wave with decreasePerSecondFactor</param>
    /// <param name="spreadSpeedFactor">modifier for the spreadSpeed of a wave. Multiplies the baseSpreadSpeed of a Wave with spreadSpeedFactor</param>
    public void AddWave(float center, float widthFactor = 1F, float amplitudeFactor = 1F, float decreasePerSecondFactor = 1F, float spreadSpeedFactor = 1F)
    {
        //part of the wave that goes to the right
        Waves.Add(new Wave(center, _BaseWidth * widthFactor, _BaseAmplitude * 0.5F * amplitudeFactor, _BaseDecreasePerSecond * decreasePerSecondFactor, _BaseSpreadSpeed * spreadSpeedFactor));

        //part of the wave that goes to the left
        Waves.Add(new Wave(center, _BaseWidth * widthFactor, _BaseAmplitude * 0.5F * amplitudeFactor, _BaseDecreasePerSecond * decreasePerSecondFactor, -_BaseSpreadSpeed * spreadSpeedFactor));
    }
    
    float[] GetSamples(float minX, float maxX, int numSamples)
    {
        float[] tmp;
        return GetSamples(minX, maxX, numSamples, out tmp);
    }
    /// <summary>
    /// Gets numSamples points within [minX, maxX)
    /// </summary>
    float[] GetSamples(float minX, float maxX, int numSamples, out float[] xValues)
    {
        float[] samples = new float[numSamples];
        xValues = new float[numSamples];

        float x = minX;

        float stepSize = (maxX - minX) / (float)numSamples;
        for (int i = 0; i < numSamples; i++)
        {
            samples[i] = SampleAllWavesAt(x);
            xValues[i] = x;
            x += stepSize;
        }
        return samples;
    }

    float SampleAllWavesAt(float x)
    {
        float result = 0;
        foreach (Wave wave in Waves)
        {
            result += wave.GetSample(x);
        }
        return result + ZeroLevel;
    }

    void OnDrawGizmos()
    {
        int numSamples = 500;

        float[] xValues;
        float[] yValues = GetSamples(LeftBorder, RightBorder, numSamples, out xValues);

        for(int i = 0; i < xValues.Length - 1; i++)
        {
            Gizmos.DrawLine(new Vector2(xValues[i], yValues[i]), new Vector2(xValues[i+1], yValues[i+1]));
        }
    }
}
