using UnityEngine;
using System.Collections;
using System;

public static class InputController {

    public static float PaddleMovement(int playerIndex)
    {
        if(Input.GetJoystickNames()[playerIndex - 1] != "")
        {
            return Input.GetAxis("P" + playerIndex + "_XAxis");
        }
        else
        {
            if (playerIndex == 1)
            {
                float input = 0;
                input += Input.GetKey(KeyCode.A) ? -1 : 0;
                input += Input.GetKey(KeyCode.D) ? 1 : 0;
                return input;
            }
            else if (playerIndex == 2)
            {
                float input = 0;
                input += Input.GetKey(KeyCode.J) ? -1 : 0;
                input += Input.GetKey(KeyCode.L) ? 1 : 0;
                return input;
            }
            else
            {
                Debug.Log("Not Implemented: Default PaddleMovement for playerIndex=" + playerIndex);
                return 0;
            }
        }
    }

    public static float BallTargeting(int playerIndex)
    {
        if (Input.GetJoystickNames()[playerIndex - 1] != "")
        {
            return Input.GetAxis("P" + playerIndex + "_TargetingAxis");
        }
        else
        {
            if (playerIndex == 1)
            {
                float input = 0;
                input += Input.GetKey(KeyCode.Q) ? -1 : 0;
                input += Input.GetKey(KeyCode.E) ? 1 : 0;
                return input;
            }
            else if (playerIndex == 2)
            {
                float input = 0;
                input += Input.GetKey(KeyCode.U) ? -1 : 0;
                input += Input.GetKey(KeyCode.O) ? 1 : 0;
                return input;
            }
            else
            {
                Debug.Log("Not Implemented: Default BallTargeting for playerIndex=" + playerIndex);
                return 0;
            }
        }
    }

    public static bool Shoot(int playerIndex)
    {
        if (Input.GetJoystickNames()[playerIndex - 1] != "")
        {
            return Input.GetButton("P" + playerIndex + "_XButton");
        }
        else
        {
            if (playerIndex == 1)
            {
                return Input.GetKey(KeyCode.W);
            }
            else if (playerIndex == 2)
            {
                return Input.GetKey(KeyCode.I);
            }
            else
            {
                Debug.Log("Not Implemented: Default Shoot for playerIndex=" + playerIndex);
                return false;
            }
        }
    }


}
