using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slotholder : MonoBehaviour {

    public GameObject left, right;
    public GameObject[] SlotMachine;
    private float[] distance;
    private float[] SlotWidth;
    Animator test;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < SlotMachine.Length; i++)
        {
            Debug.Log(SlotMachine[i].name);
            SlotWidth[i] = GetWidth(SlotMachine[i]);
            distance[i] = SlotWidth[i];

            Instantiate(left).transform.position = SlotMachine[i].transform.position - new Vector3(distance[i] / 2, 0f);
            Instantiate(right).transform.position = SlotMachine[i].transform.position + new Vector3(distance[i] / 2, 0f);
        }    

        //gameObject.transform.position = new Vector3(0f,4.6f,0f);  
    }

    private void UpdateView()
    {

    }

    private float GetWidth(GameObject Obj)
    {
        return Obj.GetComponent<BoxCollider2D>().bounds.size.x;
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
