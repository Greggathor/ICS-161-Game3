using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player1;

	private Vector3 offset;

	void Start(){
		offset = transform.position - player1.transform.position;
	}

	void LateUpdate(){
		transform.position = player1.transform.position + offset;
	}
}
