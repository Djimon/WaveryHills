using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
	public void LoadLevel(string name)
	{
		Debug.Log("level changed to "+name);
		Brick.breakableNumber = 0;
		SceneManager.LoadScene(name);
	}
	
	
	public void LoadNextLevel()
	{
		Brick.breakableNumber = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
