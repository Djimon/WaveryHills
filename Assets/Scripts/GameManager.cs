using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    /* ToDO:
     * Manage Ownership : Ball und Paddle
     * Paddle -Fadeout (Sprite) und Collision aus
     * paddle -Fadein (Sprite) und Collision an
     * Manage PowerUp -> Schicke an Owner
     * Zähle Punkte
     */
    enum PowerUps
    {
        BigBall, //Balll über der Welle wir größer
        x2, // 10 sek zählt jedes Tor doppelt
        x3, // 10 sek zählt jedes Tor 3fach
        Tsunami // Amplitude höher
    }

    static GameObject currentOwner;
    static GameObject lastOwner;
    static int Controller;

    static Text scoreP1, scoreP2;
    static int points_P1, points_P2;

    public Ball ball;

    private Animator SlotMachine, SHLeft, SHRight;
    // Use this for initialization
    void Start ()
    {
        
        lastOwner    = GameObject.Find("Player2");
        currentOwner = GameObject.Find("Player1");
        UpdateOwner();
        Controller   = currentOwner.GetComponent<Paddle>().Controller;
        
        scoreP1      = GameObject.Find("Score_P1").GetComponent<Text>();
        scoreP2      = GameObject.Find("Score_P2").GetComponent<Text>();
        points_P1    = 0;
        points_P2    = 0;

        SlotMachine  = GameObject.Find("SlotMachine").GetComponent<Animator>();
        SHLeft       = GameObject.Find("SHLeft").GetComponent<Animator>();
        SHRight      = GameObject.Find("SHRight").GetComponent<Animator>();

        GameObject.Instantiate(ball);
    }

    /// <summary>
    /// returns the current active Player (Paddle)
    /// </summary>
    /// <returns>GameObject</returns>
    public static GameObject GetOwner()
    {
        return currentOwner;
    }

    public static int GetControler()
    {
        return Controller;
    }
    public static void ChangeOwner()
    {
        GameObject Temp = lastOwner;
        lastOwner = currentOwner;
        currentOwner = Temp;
        UpdateOwner();  
        Controller = currentOwner.GetComponent<Paddle>().Controller; 
    }

    private static void UpdateOwner()
    {
        SpriteRenderer last = lastOwner.GetComponent<SpriteRenderer>();
        SpriteRenderer know = currentOwner.GetComponent<SpriteRenderer>();
        last.color = new Color(last.color.r, last.color.g, last.color.b, 0.3f);
        know.color = new Color(know.color.r, know.color.g, know.color.b, 1f);
    }

    // Update is called once per frame
    void Update ()
    {
        		
	}

    public static void UpdateScore()
    {
        scoreP1.text = points_P1.ToString();
        scoreP2.text = points_P2.ToString();
    }

    public static void AddPoint(int Player)
    {
        if (Player == 1)
            points_P1++;
        if (Player == 2)
            points_P2++;        
    }
}
