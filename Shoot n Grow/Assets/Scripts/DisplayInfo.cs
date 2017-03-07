using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInfo : MonoBehaviour {

	public GameObject panel;
	public GameObject text;

	//public GameObject[] otherText;

	void OnTriggerStay(Collider other){
		if(other.gameObject.CompareTag("Player")){
			/*
			for (int i = 0; i < otherText.Length; i++) {
				if (otherText [i].activeSelf) {
					return;
				}
			}
			//*/

			if (panel.activeSelf) {
				return;
			}

			panel.SetActive(true);
			text.SetActive(true);
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.CompareTag("Player")){
			/*
			for (int i = 0; i < otherText.Length; i++) {
				if (otherText [i].activeSelf) {
					return;
				}
			}
			//*/

			if (!text.activeSelf) {
				return;
			}

			panel.SetActive(false);
			text.SetActive(false);
		}
	}
}
