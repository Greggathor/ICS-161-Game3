using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    public Sprite[] HeartSprites;
    public Image HeartUI;
    public int health;


	// Use this for initialization
	void Start () {
    health = 5;
	}

    public void LoseHealth(){
        health--;
        HeartUI.sprite = HeartSprites[health];
    }
}
