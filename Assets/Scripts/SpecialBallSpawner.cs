using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBallSpawner : MonoBehaviour {

    public static SpecialBallSpawner Instance;

    [SerializeField]
    GameObject SoccerBallTemplate;
    
    public Transform LeftSpawnPosition;
    public Transform MidSpawnPosition;
    public Transform RightSpawnPosition;

    // Use this for initialization
    void Start () {
        if(Instance != null)
        {
            Debug.LogError("there are more than one SpecialBallSpawners in the scene.");
        }
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBalls(6, Position.Mid);
        }

	}

    public enum Position
    {
        Left,
        Mid,
        Right
    }

    public void SpawnBalls(int numSoccerBalls, Position position)
    {
        StartCoroutine(SpawnBallsWithDelay(numSoccerBalls, position));
    }

    IEnumerator SpawnBallsWithDelay(int numSoccerBalls, Position position)
    {
        while(numSoccerBalls > 0)
        {
            GameObject newBall = Instantiate(SoccerBallTemplate);
            switch (position)
            {
                case Position.Left:
                    newBall.transform.position = LeftSpawnPosition.position;
                    break;

                case Position.Mid:
                    newBall.transform.position = MidSpawnPosition.position;
                    break;

                case Position.Right:
                    newBall.transform.position = RightSpawnPosition.position;
                    break;

            }
            newBall.tag = "ExtraSoccerBall";

            numSoccerBalls--;

            yield return new WaitForSeconds(0.4F);
        }
    }

}
