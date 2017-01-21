using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slotholder : MonoBehaviour {

    public GameObject left,right,SlotMachine;
    public float distance;
    private float SlotWidth;

    // Use this for initialization
    void Start()
    {
        SlotWidth = distance = GetWidth(SlotMachine);
        //gameObject.transform.position = new Vector3(0f,4.6f,0f);        
        Instantiate(left).transform.position = transform.position - new Vector3(distance/2,0f);
        Instantiate(right).transform.position = transform.position + new Vector3(distance / 2, 0f);

    }

    private float GetWidth(GameObject Obj)
    {
        return (Obj.transform.TransformPoint(0, 0, 0).x - Obj.transform.TransformPoint(1, 1, 0).x);
    }

    // Update is called once per frame
    void Update ()
    {
		
    }
    /// <summary>
    /// Fades out the Slotmachine and shows a Timer during the PowerUp
    /// </summary>
    public void ReleasePowerUP()
    {

    }
    /// <summary>
    /// After PowerUp changes the view form Timer to SlotMachine
    /// </summary>
    public void ResetSlotMachine()
    {
    }
}
