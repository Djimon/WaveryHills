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
	
	private void MoveWithMouse()
	{
		
		float mousePosInBlocks;
		mousePosInBlocks = Input.mousePosition.x /Screen.width *16;  // 16=gamesize (blocks)
		//print (mousePosInBlocks); //left: 0  middle: 8  right: 16
		paddlePos.x = Mathf.Clamp (mousePosInBlocks,0.5f,15.5f); //0.5 is half-width of paddle
		this.transform.position = paddlePos;
	}

    private void MoveWithGamePad(int No)
    {
        float joystickPos = Input.GetAxis("P" + No + "_XAxis");
        paddlePos.x += joystickPos * MaxMoveSpeed * Time.deltaTime;
        paddlePos.x = Mathf.Clamp(paddlePos.x, 0.5f, 15.5f);
        this.transform.position = paddlePos;
    }

    private void MoveWithKeyboard(int No)
    {
        if (No == 1)
        { }
        else if (No == 2)
        { }
        else
            Debug.Log("Please implement Keyboard-controller");
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
        MoveWithGamePad(Controller);
        //MoveWithMouse();
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
