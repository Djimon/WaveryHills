using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAffected : MonoBehaviour {

    WaveManager WaveManager;

    [SerializeField]
    float _PushForce;

    // Use this for initialization
    void Start ()
    {
        WaveManager = FindObjectOfType<WaveManager>();
    }

    Vector3? closestPosition = Vector3.zero;
    
	void FixedUpdate ()
    {
        closestPosition = null;

        Vector2 ballPos = transform.position;

        if(ballPos.y < WaveManager.SampleAllWavesAt(ballPos.x))
        {
            float[] waveX;
            float[] waveY = WaveManager.GetSamples(WaveManager.LeftBorder, WaveManager.RightBorder, 500, out waveX);

            float minDist = float.MaxValue;
            int minIndex = 0;
            for (int i = 0; i < waveY.Length; i++)
            {
                float distance = Vector2.Distance(ballPos, new Vector2(waveX[i], waveY[i]));
                if (distance < minDist)
                {
                    minDist = distance;
                    minIndex = i;
                }
            }
            GetComponent<Rigidbody2D>().AddForce(_PushForce * (new Vector2(waveX[minIndex], waveY[minIndex]) - ballPos) / minDist);

            closestPosition = new Vector2(waveX[minIndex], waveY[minIndex]);
        }
        
    }

    void OnDrawGizmos()
    {
        if(closestPosition.HasValue)
            Gizmos.DrawLine(transform.position, closestPosition.Value);
    }
}
