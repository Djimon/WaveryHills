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
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
