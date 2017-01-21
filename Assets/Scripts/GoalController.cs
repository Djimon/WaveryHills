using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GoalController : MonoBehaviour {

    public GameObject SoccerBall;
    public int Player;
    public GameObject Light;
	// Use this for initialization
	void Start ()
    {
        Debug.LogError("?: " + Light.name);
	}

    void OnTriggerEnter2D(Collider2D trigger)
    {
        // Resett Ballposistion
        Light.SetActive(true);
        Invoke("LightOut", 0.5f);
        GameManager.AddPoint(Player);
        GameManager.UpdateScore();
        SoccerBall.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
        SoccerBall.GetComponent<Transform>().position = new Vector3(0f,7f,0f);    
    }

    private void LightOut()
    {
        Light.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
