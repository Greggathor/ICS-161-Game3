using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour {

    public int health;

    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Shot")){
			health--;

			if (health <= 0) {
				Destroy (gameObject);
			}
        }
    }
}
