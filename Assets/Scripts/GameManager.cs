﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

    public static GameManager Instance { get; private set; }

    public enum Player
    {
        One,
        Two,
    }

    enum PowerUps
    {
        BigBall, //Balll über der Welle wir größer
        x2, // 10 sek zählt jedes Tor doppelt
        x3, // 10 sek zählt jedes Tor 3fach
        Tsunami // Amplitude höher
    }

    LevelManager LevelManger;
    GameObject currentOwner;
    GameObject lastOwner;
    int Controller;

    Text scoreP1, scoreP2;
    public int PointsWinCondition;
    public int points_P1 {get;private set;}
    public int points_P2 { get;private set; }
    public string winner { get; private set; }


    public Ball ball;

    private Animator SlotMachine, SHLeft, SHRight;
    // Use this for initialization
    void Awake()
    {
        
    }

    void Start ()
    {
        Instance = this;
        
        lastOwner    = GameObject.Find("Player2");
        currentOwner = GameObject.Find("Player1");
        UpdateOwner();
        Controller   = currentOwner.GetComponent<Paddle>().Controller;
        
        scoreP1      = GameObject.Find("Score_P1").GetComponent<Text>();
        scoreP2      = GameObject.Find("Score_P2").GetComponent<Text>();
        points_P1    = 0;
        points_P2    = 0;

        //SlotMachine  = GameObject.Find("SlotMachine").GetComponent<Animator>();

        //GameObject.Instantiate(ball);
        UpdateScore();
        LevelManger = GameObject.FindObjectOfType<LevelManager>();
    }

    /// <summary>
    /// Sends the color of the current Paddle when true or color of last Paddle when false
    /// </summary>
    /// <param name="current">curront or last</param>
    /// <returns></returns>
    public Color SendColor(bool current)
    {
        if (current)
        {
            if (Controller == 1)
                return new Color(0f, 255f, 200f);
            else if (Controller == 2)
                return new Color(255f, 152, 0f);
            else return new Color(255f, 255f, 255f);
        }
        else
        {
            if (Controller == 2)
                return new Color(0f, 255f, 200f);
            else if (Controller == 1)
                return new Color(255f, 152, 0f);
            else return new Color(255f, 255f, 255f);
        }

    }

    /// <summary>
    /// returns the current active Player (Paddle)
    /// </summary>
    /// <returns>GameObject</returns>
    public GameObject GetOwner()
    {
        return currentOwner;
    }

    public int GetControler()
    {
        return Controller;
    }
    
    public void ChangeOwner()
    {
        GameObject Temp = lastOwner;
        lastOwner = currentOwner;
        currentOwner = Temp;
        UpdateOwner();  
        Controller = currentOwner.GetComponent<Paddle>().Controller;
        StartCoroutine(ToggleColliders(currentOwner.GetComponent<Collider2D>(), lastOwner.GetComponent<Collider2D>()));
    }

    private void UpdateOwner()
    {
        SpriteRenderer last = lastOwner.GetComponent<SpriteRenderer>();
        SpriteRenderer know = currentOwner.GetComponent<SpriteRenderer>();
        last.color = new Color(last.color.r, last.color.g, last.color.b, 0.3f);
        know.color = new Color(know.color.r, know.color.g, know.color.b, 1f);
    }

    IEnumerator ToggleColliders(Collider2D enableCollider, Collider2D disableCollider)
    {
        yield return new WaitForSeconds(0.1F);

        enableCollider.enabled = true;
        disableCollider.enabled = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (points_P1 >= PointsWinCondition)
            Win(Player.One);
        if (points_P2 >= PointsWinCondition)
            Win(Player.Two);
    }

    private void Win(Player player)
    {
        LevelManger.LoadLevel("Win");
        winner = "Player "+player.ToString();    
    }

    public void UpdateScore()
    {
        scoreP1.text = points_P1.ToString();
        scoreP2.text = points_P2.ToString();
    }

    public void AddPoint(Player Player)
    {
        if (Player == Player.One)
            points_P1++;
        if (Player == Player.Two)
            points_P2++;        
    }

    public string GetCurrentMethod()
    {
        StackTrace st = new StackTrace();
        StackFrame sf = st.GetFrame(1);

        return sf.GetMethod().Name;
    }

}
