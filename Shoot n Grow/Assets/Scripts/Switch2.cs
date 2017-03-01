using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2 : MonoBehaviour {

    public GameObject obstacle;
    public GameObject flag;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            obstacle.SetActive(false);
            //flag.SetActive(true);
        }
    }
}
