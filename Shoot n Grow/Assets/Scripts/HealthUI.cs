using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    public Sprite[] HeartSprites;
    public Image HeartUI;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        GameObject healthobject = GameObject.Find("Player1");
        Health healthaccess = healthobject.GetComponent<Health>();

        HeartUI.sprite = HeartSprites[healthaccess.health];

	}
}
