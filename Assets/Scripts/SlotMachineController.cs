using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineController : MonoBehaviour {

    public Sprite FrameUnlit;
    public Sprite No1Unlit;
    public Sprite No2Unlit;
    public Sprite No3Unlit;

    public Sprite FrameOrange;
    public Sprite No1Blue;
    public Sprite No2Blue;
    public Sprite No3Blue;

    public GameObject specialBallSpawnerOwner;
    public SpecialBallSpawner.Position slotPosition;

    SpecialBallSpawner specialBallSpawner;

    SpriteRenderer Frame;
    SpriteRenderer Number;

    float timeToElapse = 0;
    float timeToElapseThreshold = 0.3f;
    float elapsedTime = 0;

    bool isTriggered = false;
    int iterator = 0;
    int counter = 5;
    int generatedNumber = 1;

    // Use this for initialization
    void Start() {
        GameObject FrameObject = transform.FindChild("Frame").gameObject;
        GameObject NumberObject = transform.FindChild("Number").gameObject;
        if (FrameObject != null)
        {
            Frame = FrameObject.GetComponent<SpriteRenderer>();
        }
        if (NumberObject != null)
        {
            Number = NumberObject.GetComponent<SpriteRenderer>();
        }

        if (specialBallSpawnerOwner != null)
        {
            specialBallSpawner = specialBallSpawnerOwner.GetComponent<SpecialBallSpawner>();
        }
	}

    // Update is called once per frame
    void Update() {
        if (isTriggered)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > timeToElapse)
            {
                generatedNumber = (iterator % 3) + 1;
                ChangeNumber(generatedNumber);
                elapsedTime = 0;
                iterator++;
            }

            // Interpolate the time to elapse to make the number switch go slower and slower...
            if (timeToElapse < timeToElapseThreshold) 
            {
                timeToElapse += EaseInExpo(0.001f, Time.deltaTime, 0, 2);
            }
            else
            {
                counter--;
            }

            // We are done, reset everything
            if (counter == 0)
            {
                ChangeNumber(Random.Range(1,4));
                specialBallSpawner.SpawnBalls(generatedNumber, slotPosition);
                isTriggered = false;
                counter = 5;
                iterator = 0;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainSoccerBall" && !isTriggered)
        {
            timeToElapseThreshold = Random.Range(0.25f, 0.5f);
            isTriggered = true;
        }
    }

    void ChangeNumber(int number)
    {
        if (number == 1)
        {
            Number.sprite = No1Blue;
        }
        if (number == 2)
        {
            Number.sprite = No2Blue;
        }
        if (number == 3)
        {
            Number.sprite = No3Blue;
        }
    }

    float EaseInExpo(float delta, float time, float start, float duration)
    {
        return delta * Mathf.Pow(2, 10 * (time / duration)) + start;
    }
}
