using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slotholder : MonoBehaviour {

    public GameObject left,right,SlotMachine;
    public float distance;
    private float SlotWidth;
    Animator test;

    // Use this for initialization
    void Start()
    {
        SlotWidth =  GetWidth(SlotMachine);
        distance = SlotWidth;
        Debug.LogWarning("distance: " + SlotWidth);
        //gameObject.transform.position = new Vector3(0f,4.6f,0f);  
        Instantiate(left).transform.position = transform.position - new Vector3(distance / 2, 0f);
        Instantiate(right).transform.position = transform.position + new Vector3(distance / 2, 0f);

    }
    private void UpdateView()
    {
        left.transform.position = transform.position - new Vector3(distance / 2, 0f);
        right.transform.position = transform.position + new Vector3(distance / 2, 0f);
    }
    private float GetWidth(GameObject Obj)
    {
        return Obj.GetComponent<BoxCollider2D>().bounds.size.x;
    }

    // Update is called once per frame
    void Update ()
    {
        UpdateView();
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
