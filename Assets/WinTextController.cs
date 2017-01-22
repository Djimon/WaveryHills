using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTextController : MonoBehaviour {

    public Text player1Score, player2Score, wintext;

	// Use this for initialization
	void Start () {
        player1Score.text = GameManager.Instance.points_P1.ToString();
        player2Score.text = GameManager.Instance.points_P2.ToString();
        wintext.text = "Congratlation, " + GameManager.Instance.winner + " you won!";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
