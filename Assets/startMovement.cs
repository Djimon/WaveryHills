using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMovement : MonoBehaviour {

    public Vector2 StartMovement;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = StartMovement;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
