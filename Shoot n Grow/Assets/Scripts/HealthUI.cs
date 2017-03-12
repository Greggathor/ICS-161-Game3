using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    public Sprite[] HeartSprites;
    public Image HeartUI;
    public int health;

	public void LoseHealth(int damage){
        health -= damage;
		if (health < 0) {
			health = 0;
		}
        HeartUI.sprite = HeartSprites[health];
    }
}
