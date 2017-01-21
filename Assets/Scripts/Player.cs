using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    Paddle paddle;

    //Constructor
    public Player(int No)
    {
        switch (No)
        {
            case 1: paddle = GameObject.Find("Player1").GetComponent<Paddle>();
                break;
            case 2: paddle = GameObject.Find("Player2").GetComponent<Paddle>();
                break;
        }

    }
	

}
