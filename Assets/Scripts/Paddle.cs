using UnityEngine;
using System.Collections;
using System;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	private Ball ball;
    public int Controller;
    Vector3 paddlePos;
    // Use this for initialization
    void Start () 
	{
		ball = GameObject.FindObjectOfType<Ball>();
        paddlePos = new Vector3(8f, 0.5f, 0f);
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
        if (No == 1)
        {
            float joystickPos = Input.GetAxis("P1_XAxis") / Screen.width * 16;
            paddlePos.x = Mathf.Clamp(joystickPos, 0.5f,15.5f);
            this.transform.position = paddlePos;
        }
        else if (No == 2)
        {
            float joystickPos = Input.GetAxis("P2_XAxis") / Screen.width * 16;
            paddlePos.x = Mathf.Clamp(joystickPos, 0.5f, 15.5f);
            this.transform.position = paddlePos;
        }
        else
            Debug.Log("Please implement Gamepad-controller");
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

    private void AutoPlay()
	{
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, 0.5f, 15.5f); //0.5 is half-width of paddle
		this.transform.position = paddlePos;
		
	}
	
	private void OnCollisionEnter2D(Collision2D col) 
	{
        col.gameObject.GetComponent<Ball>().ChangeOwner(this.gameObject); 

	}
	
	// Update is called once per frame
	void Update () 
	{
        MoveWithGamePad(Controller);
        MoveWithMouse();
        if (Input.GetButton("P1_AButton"))
        {
            Debug.Log("PowerUp Player 1");
        }

        if (Input.GetButton("P2_AButton"))
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
