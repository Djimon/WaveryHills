using UnityEngine;
using System.Collections;
using System;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	//private Ball ball;
    public int Controller;
    Vector3 paddlePos;

    public float MaxMoveSpeed = 1;

    // Use this for initialization
    void Start () 
	{
        //ball = GameObject.FindObjectOfType<Ball>();
        paddlePos = this.transform.position;
        //print(ball);	
    }

    private void Move(float xMovementInput)
    {
        paddlePos.x += xMovementInput * MaxMoveSpeed * Time.deltaTime;
        paddlePos.x = Mathf.Clamp(paddlePos.x, 0.5f, 15.5f);
        this.transform.position = paddlePos;
    }

 //   private void AutoPlay()
	//{
	//	Vector3 ballPos = ball.transform.position;
	//	paddlePos.x = Mathf.Clamp (ballPos.x, 0.5f, 15.5f); //0.5 is half-width of paddle
	//	this.transform.position = paddlePos;
		
	//}
	
	private void OnCollisionEnter2D(Collision2D col) 
	{
        Debug.Log("bounce bounce");
	}
	
	// Update is called once per frame
	void Update () 
	{
        Move(InputController.PaddleMovement(Controller));

        // other stuff
        if (Input.GetButton("P1_XButton"))
        {
            Debug.Log("PowerUp Player 1");
        }

        if (Input.GetButton("P2_XButton"))
        {
            Debug.Log("PowerUp Player 2");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("PowerUp Keyboard");
        }
        //AutoPlay(); // Debug-Modus			
    }


}
