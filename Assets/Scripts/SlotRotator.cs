using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotRotator : MonoBehaviour {

    public Vector3 rotationalAxis;
    float rotationFactor = 1000;

    /* Vorschlag:
     * Die Rotationsgeschwindigkeit der einzelnen Slots mit Random.Range unterschiedlich schnell machen
     */

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (rotationFactor > 0)
            rotationFactor -= EaseInExpo(2, Time.deltaTime, 0, 10);
        else
            rotationFactor = 0;
        transform.Rotate(rotationalAxis.x * Time.deltaTime * rotationFactor, rotationalAxis.y * Time.deltaTime * rotationFactor, rotationalAxis.z * Time.deltaTime * rotationFactor);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball" && rotationFactor == 0)
        {
            rotationFactor = 1000;
        }
    }

    float EaseInExpo(float delta, float time, float start, float duration)
    {
        return delta * Mathf.Pow(2, 10 * (time / duration)) + start;
    }
}
