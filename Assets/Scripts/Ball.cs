using UnityEngine;
using System.Collections;
using System;

public class Ball : MonoBehaviour {

    public Vector3 StartPos;
	private Paddle paddle;
	
	private Vector3 paddleToBallVector;
	private bool klicked = false;

    void Awake()
    {
        klicked = false;
    }
	// Use this for initialization
	void Start () 
	{
        klicked = false;
		paddle = GameObject.FindObjectOfType<Paddle>();
        this.transform.position = paddle.transform.position + new Vector3(0f,1f,0f);
        paddleToBallVector = this.transform.position - paddle.transform.position; //DebugModus
        
        //paddleToBallVector = this.transform.position - StartPos;
		//print(paddleToBallVector);;
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
        if (col.gameObject.name.Contains("Player"))
            GameManager.ChangeOwner();
	}

    // Update is called once per frame
    void Update () 
	{		
		if (!klicked)
		{
			this.transform.position = paddle.transform.position + paddleToBallVector; 				
		
			if (Input.GetMouseButtonDown(0))
			{
				klicked = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,12f);	// set y to a value, not a magic number			
			}

            if (GameManager.GetControler() == 1 && Input.GetButton("P1_XButton"))
            { 
                klicked = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 12f);

            }
            else if (GameManager.GetControler() == 2 && Input.GetButton("P2_XButton"))
            {
                klicked = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 12f);
            }              
            else
                Debug.Log("Please implement Gamepad-controller");
        }
			
	}

}
