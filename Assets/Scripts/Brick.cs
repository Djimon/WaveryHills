using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	//go to inspector and make a new Tag, to manage all different bricks e.g. "breakable"
	//then select all brick-prefables and tag them wtih breakable

	public AudioClip crack;
	public static int breakableNumber = 0;	
	public GameObject smoke;
	
	private int timesHit;
	private LevelManager levelmanger;
	private bool isBreakable;
	
	public Sprite[] hitBricks;

	// Use this for initialization
	void Start () 
	{
		isBreakable = (this.tag == "Breakable");
		if (isBreakable)
		{
			breakableNumber++;
			print (breakableNumber);
		}
		timesHit = 0;
		levelmanger = GameObject.FindObjectOfType<LevelManager>();
		
	}
	
	void Update () 
	{
				
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (isBreakable)
		{			
			HandelHits();
		}
		//SimulateWin();			
	}
	
	void HandelHits()
	{
		AudioSource.PlayClipAtPoint(crack,transform.position); //play sound "crack" where brick was hit		
		timesHit++;
		int maxHits = hitBricks.Length +1;
		//print ("Collision"); //detect if is collision
		if (timesHit >= maxHits)
		{
			//print ("killed");
			breakableNumber--;
			print (breakableNumber);
			EmmitSmoke ();
			levelmanger.BrickDestroyed();
			GetComponent<AudioSource>().Play();
			Destroy(gameObject);						
		}
		else
		{
			LoadSprites();
		}	
	}
	
	void EmmitSmoke()
	{
		//instanzieiert smoke at position of this gameobject, with standart rotation
		GameObject smokePuff = Instantiate(smoke,transform.position, Quaternion.identity) as GameObject;
		// set color of smoke to the color of the brick
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites()
	{
		int spriteIndex = timesHit -1;
		if (hitBricks[spriteIndex]) // if hitsprite exists, set it, otherwise leave it 
		{
			this.GetComponent<SpriteRenderer>().sprite = hitBricks[spriteIndex];
		}
		else
		{
			Debug.LogError("brick sprite missing");
		}
	}
	
	//TODO: Remove, just testing
	void SimulateWin()
	{
		levelmanger.LoadNextLevel();		
	}
	

}
