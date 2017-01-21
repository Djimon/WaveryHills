using UnityEngine;
using System.Collections;

public class LooseCollider : MonoBehaviour {

	private LevelManager levelManager;
    private GameManager GameManager;
    public Ball ball;
	
	void Start()
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
        GameManager = GameObject.FindObjectOfType<GameManager>();
        ball = GameObject.FindObjectOfType<Ball>();
	}

	void OnTriggerEnter2D(Collider2D trigger)
	{
        //print ("Trigger"); // detect whether is trigger
        //levelManager.LoadLevel("Lose");
        Destroy(ball);
        Debug.Log("Loose: " + GameManager.GetOwner().name);
        GameManager.ChangeOwner();
        Instantiate(GameManager.ball);   
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		print ("Collision"); //detect if is collision
		
	}


}
