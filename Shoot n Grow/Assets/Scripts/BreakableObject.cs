using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour {

    public int hitcount;

    // Use this for initialization
    void Start () {

    hitcount = 0;
        
    }
    
    // Update is called once per frame
    void Update () {

    if(hitcount >= 1)
    {
        Destroy(gameObject);
    }

    //End of Update 
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Shot")){
            hitcount++;
        }
    }
}
