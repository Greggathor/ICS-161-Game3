using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed;
	//public float angle; //debug
	public float rAngleX;
	public float rAngleY;
	public Vector3 reflectedAngle;
	public float offsetAngle;
	public char shotDirection;

	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.up * speed;
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("Reflector")) {
			Vector3 reflectedAngle = Vector3.Reflect (rb.transform.up, other.transform.up);
			rAngleX = reflectedAngle.x;
			rAngleY = reflectedAngle.y;
			//transform.eulerAngles = reflectedAngle;
			//transform.eulerAngles = new Vector3(0.0f, 0.0f, angle);

			//if (reflectedAngle.y == 1.0f) {
			//if(rAngleY == 1.0f){
			if(rAngleY < 1.1f && rAngleY > 0.9f){
				transform.eulerAngles = new Vector3 (0.0f, transform.eulerAngles.y, 0.0f + offsetAngle);
				shotDirection = 'u';
			} 
			//else if (reflectedAngle.y == -1.0f) {
			//else if (rAngleY == -1.0f) {
			else if(rAngleY > -1.1f && rAngleY < -0.9f){
				transform.eulerAngles = new Vector3 (0.0f, transform.eulerAngles.y, 180.0f + offsetAngle);
				shotDirection = 'd';
			} 
			//else if (reflectedAngle.x == 1.0f) {
			//else if (rAngleX == 1.0f) {
			else if(rAngleX < 1.1f && rAngleX > 0.9f){
				transform.eulerAngles = new Vector3 (0.0f, transform.eulerAngles.y, 270.0f + offsetAngle);
				shotDirection = 'r';
			} 
			//else if (reflectedAngle.x == -1.0f) {
			//else if (rAngleX == -1.0f) {
			else if(rAngleX > -1.1f && rAngleX < -0.9f){
				transform.eulerAngles = new Vector3 (0.0f, transform.eulerAngles.y, 90.0f + offsetAngle);
				shotDirection = 'l';
			}

			rb.velocity = transform.up * speed;
		}
	}
}
