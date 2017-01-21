using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoalController : MonoBehaviour {

    public Ball SoccerBall;
    public int Player;
	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D trigger)
    {
        // Resett Ballposistion
        GameManager.AddPoint(Player);
        GameManager.UpdateScore();
        SoccerBall.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
        SoccerBall.GetComponent<Transform>().position = new Vector3(0f,7f,0f);       
    }
    // Update is called once per frame
    void Update () {
		
	}
}
