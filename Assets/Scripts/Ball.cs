using UnityEngine;
using System.Collections;
using System;

public class Ball : MonoBehaviour {

    public Vector3 StartPos;
	private Paddle paddle;
	
	private Vector3 paddleToBallVector;
	private bool klicked = false;

    public float StartSpeed = 7F;
    Vector2 StartDirection;

    void Awake()
    {
        klicked = false;
        StartDirection = Vector2.up;
    }
	// Use this for initialization
	void Start () 
	{
        Reset();
        
        //paddleToBallVector = this.transform.position - StartPos;
		//print(paddleToBallVector);;
	}

    public void Reset()
    {
        klicked = false;
        StartDirection = Vector2.up;
        paddle = GameManager.GetOwner().GetComponent<Paddle>();
        this.transform.position = paddle.transform.position + new Vector3(0f, 1f, 0f);
        paddleToBallVector = this.transform.position - paddle.transform.position;
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

            //if (Input.GetMouseButtonDown(0))
            //{
            //	klicked = true;
            //	this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,12f);	// set y to a value, not a magic number			
            //}

            int currentControllerIndex = GameManager.GetControler();

            StartDirection.x += 0.1F * Input.GetAxis("P" + currentControllerIndex + "_TargetingAxis");
            StartDirection.x = Mathf.Clamp(StartDirection.x, -0.8F, 0.8F);

            StartDirection.Normalize();
            
            if(Input.GetButton("P" + currentControllerIndex + "_XButton"))
            {
                klicked = true;
                this.GetComponent<Rigidbody2D>().velocity = StartSpeed * StartDirection;
            }
        }
			
	}

    void OnDrawGizmos()
    {
        if (!klicked)
        {
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)StartDirection);
        }
    }
}
