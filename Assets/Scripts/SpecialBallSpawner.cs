using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBallSpawner : MonoBehaviour {

    public static SpecialBallSpawner Instance;

    [SerializeField]
    GameObject SoccerBallTemplate;

    [SerializeField]
    Transform SoccerSpawnPosition;

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
            SpawnBalls(6);
        }

	}

    public void SpawnBalls(int numSoccerBalls)
    {
        SpawnBalls(numSoccerBalls, 0);
    }

    public void SpawnBalls(int numSoccerBalls, int numBreakoutBalls)
    {
        StartCoroutine(SpawnBallsWithDelay(numSoccerBalls));
    }

    IEnumerator SpawnBallsWithDelay(int numSoccerBalls)
    {
        while(numSoccerBalls > 0)
        {
            GameObject newBall = Instantiate(SoccerBallTemplate);
            newBall.transform.position = SoccerSpawnPosition.position;

            numSoccerBalls--;

            yield return new WaitForSeconds(0.4F);
        }
    }

}
