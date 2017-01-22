using UnityEngine;
using System.Collections;
using System;

public class Ball : MonoBehaviour {

    public Vector3 StartPos;
	private Paddle paddle;
	
	private Vector3 paddleToBallVector;
	private bool klicked = false;
    private SpriteRenderer BallSprite;

    public float StartSpeed = 7f;
    Vector2 StartDirection;

    [SerializeField]
    private SpriteRenderer targetArrow;

    void Awake()
    {
        klicked = false;
        StartDirection = Vector2.up;
        BallSprite = gameObject.GetComponent<SpriteRenderer>();
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
        paddle = GameManager.Instance.GetOwner().GetComponent<Paddle>();
        this.transform.position = paddle.transform.position + new Vector3(0f, 1f, 0f);
        paddleToBallVector = this.transform.position - paddle.transform.position;
        BallSprite.color = GameManager.Instance.SendColor(true);

        targetArrow.enabled = true;
        targetArrow.color = BallSprite.color;

        int currentControllerIndex = GameManager.Instance.GetControler();
        ControlVisualizer.Instance.show(currentControllerIndex, InputController.GetInputDevice(currentControllerIndex));
    }
	
	void OnCollisionEnter2D(Collision2D col)
	{
        // Collision with paddle -> Changes the owner and Color of the Disc
        if (col.gameObject.name.Contains("Player"))
        {
            GameManager.Instance.ChangeOwner();
            BallSprite.color = GameManager.Instance.SendColor(false);
        }
           

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

            int currentControllerIndex = GameManager.Instance.GetControler();

            StartDirection.x += 0.1F * InputController.BallTargeting(currentControllerIndex);
            StartDirection.x = Mathf.Clamp(StartDirection.x, -0.8F, 0.8F);

            StartDirection.Normalize();
            
            targetArrow.transform.up = StartDirection;

            if (InputController.Shoot(currentControllerIndex))
            {
                klicked = true;
                this.GetComponent<Rigidbody2D>().velocity = StartSpeed * StartDirection;

                GameManager.Instance.ChangeOwner();

                targetArrow.enabled = false;
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
