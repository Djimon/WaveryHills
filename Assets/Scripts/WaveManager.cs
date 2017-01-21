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
            AddWave(center, _BaseWidth, _BaseAmplitude, _BaseDecreasePerSecond, _BaseSpreadSpeed);
        }

        UpdateWaves();

        if(Ball.transform.position.y < SampleAllWaves(Ball.transform.position.x))
        {
            Ball.AddForce(_PushForce * Vector2.up);
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

    float SampleAllWaves(float x)
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
        float numSamples = 500;
        float stepSize = (RightBorder - LeftBorder) / numSamples;

        Vector2 previousSample = new Vector2(LeftBorder, SampleAllWaves(LeftBorder));
        Vector2 currentSample;

        for (float x = LeftBorder + stepSize; x <= RightBorder; x += stepSize)
        {
            currentSample = new Vector2(x, SampleAllWaves(x));
            Gizmos.DrawLine(previousSample, currentSample);
            previousSample = currentSample;
        }
    }
}
