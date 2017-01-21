using UnityEngine;
using System.Collections;

public class LooseCollider : MonoBehaviour {

    private GameManager GameManager;
    private Ball ball;
	
	void Start()
	{
        GameManager = GameObject.FindObjectOfType<GameManager>();
        ball = GameObject.FindObjectOfType<Ball>();
	}

	void OnTriggerEnter2D(Collider2D trigger)
	{
        GameManager.ChangeOwner();
        ball.Reset();

    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		print ("Collision"); //detect if is collision		
	}


}
