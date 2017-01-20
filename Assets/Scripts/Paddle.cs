using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	private Ball ball;
	// Use this for initialization
	void Start () 
	{
		ball = GameObject.FindObjectOfType<Ball>();
		//print(ball);	
	}
	
	void MoveWithMouse()
	{
		Vector3 paddlePos = new Vector3(8f,0.5f,0f);
		float mousePosInBlocks;
		mousePosInBlocks = Input.mousePosition.x /Screen.width *16;  // 16=gamesize (blocks)
		//print (mousePosInBlocks); //left: 0  middle: 8  right: 16
		paddlePos.x = Mathf.Clamp (mousePosInBlocks,0.5f,15.5f); //0.5 is half-width of paddle
		this.transform.position = paddlePos;
	}
	
	void AutoPlay()
	{
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f); //
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, 0.5f, 15.5f); //0.5 is half-width of paddle
		this.transform.position = paddlePos;
		
	}
	
	void OnCollisionEnter2D(Collision2D col) 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!autoPlay) 
		{
			//print (autoPlay);
			MoveWithMouse();
		}
		else 
		{
			AutoPlay();
		}
		
		
	}
}
