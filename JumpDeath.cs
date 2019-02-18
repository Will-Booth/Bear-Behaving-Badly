using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDeath : MonoBehaviour {


    public GameObject Bee;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(Bee);
            Debug.Log("Hit!");
        }
    }
}
