using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVisualizer : MonoBehaviour {

    public static ControlVisualizer Instance;

    [SerializeField]
    SpriteRenderer GamePadPlayer1;
    [SerializeField]
    SpriteRenderer KeyboardPlayer1;
    [SerializeField]
    SpriteRenderer GamePadPlayer2;
    [SerializeField]
    SpriteRenderer KeyboardPlayer2;

    // Use this for initialization
    void Start () {
        Instance = this;


	}

    public void show(int index, InputController.InputDevice inputDevice)
    {
        if(index == 1)
        {
            if(inputDevice == InputController.InputDevice.GamePad)
            {
                KeyboardPlayer1.enabled = false;
                GamePadPlayer1.enabled = true;
            }
            else if (inputDevice == InputController.InputDevice.Keyboard)
            {
                KeyboardPlayer1.enabled = true;
                GamePadPlayer1.enabled = false;
            }
        }
        else if (index == 2)
        {
            if (inputDevice == InputController.InputDevice.GamePad)
            {
                KeyboardPlayer2.enabled = false;
                GamePadPlayer2.enabled = true;
            }
            else if (inputDevice == InputController.InputDevice.Keyboard)
            {
                KeyboardPlayer2.enabled = true;
                GamePadPlayer2.enabled = false;
            }
        }
    }
}
