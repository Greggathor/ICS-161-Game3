using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOneText : MonoBehaviour {

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
