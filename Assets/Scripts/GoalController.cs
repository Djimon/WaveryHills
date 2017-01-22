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

    void Awake()
    {
        //Debug.LogError("?: " + Light.name);
    }
	// Use this for initialization
	void Start () {
        initialBallPosition = SoccerBall.transform.position;
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<AudioSource>().Play();
        Light.SetActive(true);
        Invoke("LightOut", 0.2f);
        GameManager.Instance.AddPoint(Player);
        GameManager.Instance.UpdateScore();
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
