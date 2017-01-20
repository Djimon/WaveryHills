using UnityEngine;
using System.Collections;
using System;

public class Ball : MonoBehaviour {
	
	public float minVelocity = 10.5f;
	private Paddle paddle;
	
	private Vector3 paddleToBallVector;
	private bool klicked = false;
    private int owner;

    public int GetOwner()
    {
        return this.owner;
    }
	
	
	// Use this for initialization
	void Start () 
	{
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		//print(paddleToBallVector);;
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		Vector2 tweak = new Vector2(UnityEngine.Random.Range(0f,0.5f), UnityEngine.Random.Range(0f,0.5f));
		if (klicked)
		{
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity += tweak;	
		
		
			print ("P2B: "+ (this.transform.position - paddle.transform.position) );
		
			if ((this.transform.position - paddle.transform.position).y < 1f)
			{
				//TODO: add code here, if ball is too flat
			}
	
				
			print ("old: " +this.transform.position +"Sp: " + this.GetComponent<Rigidbody2D>().velocity.magnitude); //magnitude = length
		
			if (this.GetComponent<Rigidbody2D>().velocity.magnitude < minVelocity)
			{
				this.GetComponent<Rigidbody2D>().velocity *= (float)(1.1f * (minVelocity/this.GetComponent<Rigidbody2D>().velocity.magnitude) ); 
				print ("new: " +this.transform.position +"Sp: " + this.GetComponent<Rigidbody2D>().velocity.magnitude); //magnitude = length
			}
		}

	}



    // Update is called once per frame
    void Update () 
	{		
		if (!klicked)
		{
			this.transform.position = paddle.transform.position + paddleToBallVector; 
			print ("vector: " + this.transform.position +"Sp: "+this.GetComponent<Rigidbody2D>().velocity.magnitude); //magnitude = length
		
		
			if (Input.GetMouseButtonDown(0))
			{
				//print ("klicked");	
				klicked = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(3f,12f);	// set y to a value, not a magic number
			
			}
		}
			
	}

    public void ChangeOwner(GameObject Paddle)
    {
        owner = Paddle.GetComponent<Paddle>().Controller;
        Debug.Log("Change Owner to :"+ owner);
    }
}
