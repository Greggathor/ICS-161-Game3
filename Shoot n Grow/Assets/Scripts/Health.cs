using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    public int health;

	// Use this for initialization
	void Start () {

    health = 5;
		
	}
	
	// Update is called once per frame
	void Update () {

    if(health <= 0)
    {
        //Something
    }
		
	}
}
