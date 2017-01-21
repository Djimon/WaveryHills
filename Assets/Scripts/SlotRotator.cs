using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotRotator : MonoBehaviour {

    float rotationFactor = 1000;
    const float TimeToElapse = 0.2f;
    float elapsedTime = TimeToElapse;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
        elapsedTime -= Time.deltaTime;
        if (elapsedTime <= 0 && rotationFactor > 0)
        {
            rotationFactor -= EaseInExpo(50, Time.deltaTime, 0, 5);
            elapsedTime = TimeToElapse;
        }*/
        if (rotationFactor > 0)
            rotationFactor -= EaseInExpo(2, Time.deltaTime, 0, 10);
        else
            rotationFactor = 0;
        transform.Rotate(0, Time.deltaTime * rotationFactor, 0);
	}

    float EaseInExpo(float delta, float time, float start, float duration)
    {
        return delta * Mathf.Pow(2, 10 * (time / duration)) + start;
    }
}
