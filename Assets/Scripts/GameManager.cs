using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    static int scoreP1;
    static int scoreP2;
    static int Controller;

    public Ball ball;
    // Use this for initialization
    void Start ()
    {
        lastOwner = GameObject.Find("Player2");
        currentOwner = GameObject.Find("Player1");
        UpdateView();
        Controller = currentOwner.GetComponent<Paddle>().Controller;
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
        UpdateView();  
        Controller = currentOwner.GetComponent<Paddle>().Controller; 
    }

    private static void UpdateView()
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
}
