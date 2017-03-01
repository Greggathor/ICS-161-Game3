using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour {

	private Rigidbody rb;

	private bool jump = false;
	public float jumpForce;
	public float gravity;
	private bool grounded;
	public Transform groundCheck1;
	public Transform groundCheck2;

	private float moveHorizontal = 0.0f;
	private bool facingRight = true;
	public float speed;
	public float maxSpeed;
	public float stopSpeed;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	void Update(){
		grounded = Physics.Linecast (transform.position, groundCheck1.position, 1 << LayerMask.NameToLayer ("Ground"))
			|| Physics.Linecast (transform.position, groundCheck2.position, 1 << LayerMask.NameToLayer ("Ground"));

		//if (Input.GetButtonDown ("Jump") && grounded) {
		if(Input.GetKeyDown(KeyCode.UpArrow) && grounded){
			jump = true;
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			moveHorizontal = speed;
		}
		else if (Input.GetKey (KeyCode.LeftArrow)) {
			moveHorizontal = -speed;
		}
		else {
			moveHorizontal = 0.0f;
		}

		/*
		if (!grounded && sc.enabled == true) {
			sc.enabled = false;
		}

		if (sc.enabled == false && grounded && !paperDash) {
			sc.enabled = true;
		}

		if (invincible && Time.time > invincibilityEndTime) {
			invincible = false;
			power.material = powerList[powerNumber];
		}
		//*/

		/*
		else if (powerNumber == 1) {
				if (grounded) {
					//transform.position = new Vector3 (transform.position.x, transform.position.y + translateUp);
					rb.AddForce (new Vector3 (0.0f, scissorHop, 0.0f), ForceMode.Impulse);
					ignoreGrounded = true;
				}

				if (Mathf.Sign (transform.right.x) > 0)
					rotationDirection = 0.0f;
				else
					rotationDirection = 180f;
				scissorSpin = true;

			}
			else if (powerNumber == 2) {
				rockForm = true;
				transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			}
		//*/

		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void FixedUpdate () {
		/*
		if (levelComplete) {
			return;
		}

		if (paperDash) {
			if (Input.GetKeyUp (KeyCode.F) && lowCeiling == false) {
				paperDash = false;
				transform.localScale = new Vector3 (1.0f, 1.5f, 1.0f);
				sc.enabled = true;
			}
			//if(!grounded)
			rb.velocity = new Vector3 (dashSpeed * Mathf.Sign (transform.right.x), -paperDropSpeed);
		}
		//*/


		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		rb.AddForce (movement, ForceMode.VelocityChange);

		/*
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		rb.AddForce (movement * speed, ForceMode.VelocityChange);
		//*/

		//*
		if (moveHorizontal > 0 && !facingRight)
			Flip ();
		else if (moveHorizontal < 0 && facingRight)
			Flip ();
		//*/

		if (moveHorizontal == 0 && rb.velocity.x != 0.0f && Mathf.Abs (rb.velocity.x) < stopSpeed) {
			rb.velocity = new Vector3 (0.0f, rb.velocity.y, 0.0f);
		}

		if (Mathf.Abs (rb.velocity.x) > maxSpeed)
			rb.velocity = new Vector3 (Mathf.Sign (rb.velocity.x) * maxSpeed, rb.velocity.y, 0.0f);

		if (jump) {
			rb.AddForce (new Vector3 (0.0f, jumpForce, 0.0f), ForceMode.Impulse);
			jump = false;
		} 
		else {
			rb.AddForce(new Vector3(0.0f, -gravity, 0.0f), ForceMode.Acceleration);
		}

		/*
		if (scissorSpin) {
			Quaternion deltaRotation = Quaternion.Euler((new Vector3(0.0f, 0.0f, 1.0f)) * Time.deltaTime * -rotationSpeed);
			rb.MoveRotation(rb.rotation * deltaRotation);
			if (ignoreGrounded) {
				if (!grounded)
					ignoreGrounded = false;
			}
			else if (grounded || Input.GetKeyUp (KeyCode.F)) {
				scissorSpin = false;
				transform.rotation = new Quaternion (0.0f, rotationDirection, 0.0f, 0.0f);

				//scissorSpin flip bug
				if((facingRight && transform.rotation.y != 0f) || (!facingRight && transform.rotation.y == 0f))
					transform.RotateAround(transform.position, transform.up, 180f);
			}
		}
		//*/
		//xVelocity = rb.velocity.x;
		//yVelocity = rb.velocity.y;
	}

	void Flip(){
		facingRight = !facingRight;
		transform.RotateAround(transform.position, transform.up, 180f);
	}
}
