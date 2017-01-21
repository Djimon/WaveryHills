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
        SlotWidth = distance;
        //gameObject.transform.position = new Vector3(0f,4.6f,0f);        
        Instantiate(left).transform.position = transform.position;
        Instantiate(right).transform.position = transform.position;
        

    }
	// Update is called once per frame
	void Update ()
    {
		
	}
}
