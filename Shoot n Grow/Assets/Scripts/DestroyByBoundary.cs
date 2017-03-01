﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Shot")) {
			Destroy (other.gameObject);
		}
	}
}
