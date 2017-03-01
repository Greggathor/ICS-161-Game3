using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public bool player1done;
    public bool player2done;
    public bool leveldone;

	// Use this for initialization
	void Start () {

    player1done = false;
    player2done = false;
    leveldone = false;
		
	}
	
	// Update is called once per frame
	void Update () {

    if(player1done && player2done)
    {
        leveldone = true;
    }

    if(leveldone)
    {
    //Do stuff to advance
    }

    //End of Update	
	}

    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "Player1"){
            player1done = true;
        }
        if(other.gameObject.name == "Player2"){
            player2done = true;
        }
    }

}


