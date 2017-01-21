using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GoalController : MonoBehaviour {

    public GameObject SoccerBall;
    public GameManager.Player Player;
    public GameObject Light;

    Vector3 initialBallPosition;


	// Use this for initialization
	void Start () {
        initialBallPosition = SoccerBall.transform.position;
        Debug.LogError("?: " + Light.name);
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Light.SetActive(true);
        Invoke("LightOut", 0.5f);
        GameManager.Instance.AddPoint(Player);

        // Reset Ball position
        SoccerBall.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
        SoccerBall.transform.position = initialBallPosition;       
    }

    private void LightOut()
    {
        Light.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
