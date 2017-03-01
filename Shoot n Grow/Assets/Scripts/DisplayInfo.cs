using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInfo : MonoBehaviour {

	public GameObject panel;
	public GameObject text;

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Player")){
			panel.SetActive(true);
			text.SetActive(true);
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.CompareTag("Player")){
			panel.SetActive(false);
			text.SetActive(false);
		}
	}
}
