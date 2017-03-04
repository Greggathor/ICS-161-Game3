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

	//public bool moving; // debug

	private Vector3 offset;

	void Start(){
		offset = transform.position - player1.transform.position;
	}

	void LateUpdate(){
		playerDistance = Vector3.Distance (player1.transform.position, player2.transform.position);
		midpoint = Vector3.Lerp (player1.transform.position, player2.transform.position, 0.5f);
		if (playerDistance < minDistanceZoom) {
			transform.position = new Vector3 (midpoint.x, midpoint.y, 0.0f) + offset;
		}
		else if (playerDistance > maxDistanceZoom) {
			transform.position = new Vector3 (midpoint.x, midpoint.y, -zoomRange) + offset;
		}
		else {
			transform.position = new Vector3 (midpoint.x, midpoint.y, -zoomRange * (playerDistance - minDistanceZoom) / (maxDistanceZoom - minDistanceZoom)) + offset;
		}
	}
}
