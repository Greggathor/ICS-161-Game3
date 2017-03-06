using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    public Sprite[] HeartSprites;
    public Image HeartUI;
    public int health = 5;


	// Use this for initialization
	void Start () {

    health = 5;

	}
	
	// Update is called once per frame
	void Update () {

        HeartUI.sprite = HeartSprites[health];

	}
}
