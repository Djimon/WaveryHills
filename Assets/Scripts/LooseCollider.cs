using UnityEngine;
using System.Collections;

public class LooseCollider : MonoBehaviour {

	private LevelManager levelManager;
	
	void Start()
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();	
	}

	void OnTriggerEnter2D(Collider2D trigger)
	{
        //print ("Trigger"); // detect whether is trigger
        //levelManager.LoadLevel("Lose");
        Debug.Log("Loose: " + trigger.gameObject.GetComponent<Ball>().GetOwner());
        // der andere player kriegt den Ball
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		print ("Collision"); //detect if is collision
		
	}

}
