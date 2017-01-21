using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoalController : MonoBehaviour {

    public GameObject SoccerBall;
    public GameManager.Player Player;
    Vector3 initialBallPosition;
	// Use this for initialization
	void Start () {
        initialBallPosition = SoccerBall.transform.position;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("GOAL!");
        GameManager.AddPoint(Player);
        //GameManager.UpdateScore();
        // Reset Ball position
        SoccerBall.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
        SoccerBall.transform.position = initialBallPosition;       
    }
    // Update is called once per frame
    void Update () {
		
	}
}
