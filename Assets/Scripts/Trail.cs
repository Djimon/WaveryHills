using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour {

    private TrailRenderer trail;
    SpriteRenderer parent;
	// Use this for initialization
	void Start ()
    {
        trail = GetComponent<TrailRenderer>();
        parent = GetComponentInParent<SpriteRenderer>();
	}

    public void UpdateTrail()
    {
        trail.startColor = parent.color;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}
}
