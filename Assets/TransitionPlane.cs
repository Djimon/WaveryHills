using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPlane : MonoBehaviour {

    [SerializeField]
    WaveManager waveManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.position.y < transform.position.y)
        {
            waveManager.AddWave(collision.transform.position.x);
        }
    }
}
