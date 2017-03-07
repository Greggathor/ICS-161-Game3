using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOneText : MonoBehaviour {
	/*
	public GameObject[] infoTexts;
	public GameObject winText;
	public GameObject deathText;

	void Update () {
		if (!gameObject.activeSelf) {
			return;
		}

		int first = -1;
		for (int i = 0; i < infoTexts.Length; i++) {
			if (infoTexts [i].activeSelf) {
				if (winText.activeSelf) {
					infoTexts [i].SetActive (false);
				} else if (deathText.activeSelf) {
					infoTexts [i].SetActive (false);
				} else {
					if (first != -1) {
						first = i;
					}
				}
			}
		}
	}
	//*/

	public GameObject[] otherText;
	private bool done;

	void Update(){
		if (gameObject.activeSelf && !done) {
			for (int i = 0; i < otherText.Length; i++) {
				otherText [i].SetActive (false);
			}
			done = true;
		}
	}
}
