using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPlane : MonoBehaviour {

    [SerializeField]
    WaveManager waveManager;

    Collider2D collider;

	// Use this for initialization
	void Start () {
        collider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.position.y < transform.position.y + collider.offset.y)
        {
            waveManager.AddWave(collision.transform.position.x, GameManager.Instance.SendColor(false));
        }
    }
}
