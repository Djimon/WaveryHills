using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public void LoadLevel(string name)
	{
		Debug.Log("level changed to "+name);
		Brick.breakableNumber = 0;
		Application.LoadLevel(name);
	}
	
	
	public void LoadNextLevel()
	{
		Brick.breakableNumber = 0;
		Application.LoadLevel(Application.loadedLevel +1);
	}
	
	public void Quit()
	{
		Debug.Log("quit requested");
		Application.Quit(); // bad for web or smartphones
	}
	
	public void BrickDestroyed()
	{
		if (Brick.breakableNumber <= 0)
		{
			LoadNextLevel();
		}
	}
	
	

}
