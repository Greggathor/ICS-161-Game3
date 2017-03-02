using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerCamera : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public float minDistanceZoom; //min distance between the two players before camera stops zooming in
	public float maxDistanceZoom; //max distance between the two players before camera stops zooming out
	private float playerDistance;
	private Vector3 midpoint;
	public float zoomRange;

	private Vector3 offset;

	void Start(){
		offset = transform.position - player1.transform.position;
	}

	void LateUpdate(){
		playerDistance = Vector3.Distance (player1.transform.position, player2.transform.position);
		midpoint = Vector3.Lerp (player1.transform.position, player2.transform.position, 0.5f);
		if (minDistanceZoom < playerDistance && playerDistance < maxDistanceZoom) {
			transform.position = new Vector3 (midpoint.x, midpoint.y, zoomRange * playerDistance / (maxDistanceZoom - minDistanceZoom)) + offset;
		}
		else {
			transform.position = transform.position = new Vector3 (midpoint.x, midpoint.y, transform.position.z) + offset;
		}
	}
}
