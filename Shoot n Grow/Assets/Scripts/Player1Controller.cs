using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Controller : MonoBehaviour {
	
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

	private bool tallForm = false;
	public float maxHeight;
	private float height = 1.0f;
	private bool wideForm = false;
	public float maxWidth;
	private float width = 1.0f;
	public float growthRate;

	/*
	public float rotationSpeed;
	public float maxRotation;
	private bool rotateRight = false;
	private bool rotateLeft = false;
	public float zRotation = 0.0f; //debug
	//*/

	private bool levelComplete = false;

	public GameObject infoPanel;
	public GameObject winText;
	public GameObject deathText;

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	void Update(){
		if (levelComplete) {
			if(Input.GetKey(KeyCode.Return))
				SceneManager.LoadScene ((SceneManager.GetActiveScene ().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
			return;
		}

		grounded = Physics.Linecast (transform.position, groundCheck1.position, 1 << LayerMask.NameToLayer ("Ground"))
			|| Physics.Linecast (transform.position, groundCheck2.position, 1 << LayerMask.NameToLayer ("Ground"));

		if (Input.GetButtonDown ("Jump") && grounded) {
		//if (Input.GetKeyDown(KeyCode.RightControl) && grounded) {
			jump = true;
		}

		if (Input.GetKey (KeyCode.D)) {
			moveHorizontal = speed;
			/*
			if (!tallForm)
				moveHorizontal = speed;
			else if (!rotateRight) {
				rotateRight = true;
				moveHorizontal = 0.0f;
			}
			//*/
		}
		else if (Input.GetKey (KeyCode.A)) {
			moveHorizontal = -speed;
			/*
			if (!tallForm)
				moveHorizontal = -speed;
			else if (!rotateLeft) {
				rotateLeft = true;
				moveHorizontal = 0.0f;
			}
			//*/
		}
		else {
			moveHorizontal = 0.0f;
		}

		/*
		if (tallForm) {
			if (Input.GetKeyUp (KeyCode.D)) {
				rotateRight = false;
			}
			if (Input.GetKeyUp (KeyCode.A)) {
				rotateLeft = false;
			}
		}
		//*/

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

		if(Input.GetKeyDown(KeyCode.W)){
			tallForm = true;
			//transform.localScale = new Vector3 (1.0f, 3.0f, 1.0f);
		}

		if(Input.GetKeyDown(KeyCode.S)){
			wideForm = true;
			//transform.localScale = new Vector3 (3.0f, 1.0f, 1.0f);
		}

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

		if (tallForm) {
			if (height < maxHeight) {
				height += growthRate;
				transform.localScale = new Vector3(1.0f, height, 1.0f);
			}
			if (Input.GetKeyUp (KeyCode.W)) {
				tallForm = false;
				height = 1.0f;
				transform.localScale = new Vector3(1.0f, height, 1.0f);

				//rotateRight = false;
				//rotateLeft = false;

				if(facingRight)
					transform.rotation = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
				else
					transform.rotation = new Quaternion (0.0f, 180.0f, 0.0f, 0.0f);
			}
		}
		if (wideForm) {
			if (width < maxWidth) {
				width += growthRate;
				transform.localScale = new Vector3(width, 1.0f, 1.0f);
			}
			if (Input.GetKeyUp (KeyCode.S)) {
				wideForm = false;
				width = 1.0f;
				transform.localScale = new Vector3(width, 1.0f, 1.0f);
			}
		}

		/*
		if (rotateRight) {
			if (facingRight) {
				if (transform.rotation.z > -maxRotation) {
					Quaternion deltaRotation = Quaternion.Euler ((new Vector3 (0.0f, 0.0f, 1.0f)) * -rotationSpeed);
					rb.MoveRotation(rb.rotation * deltaRotation);
				}
			} 
			else {
				if (transform.rotation.z < maxRotation) {
					Quaternion deltaRotation = Quaternion.Euler ((new Vector3 (0.0f, 0.0f, 1.0f)) * rotationSpeed);
					rb.MoveRotation(rb.rotation * deltaRotation);
				}
			}
			zRotation = transform.eulerAngles.z;
		}
		if (rotateLeft) {
			if (facingRight) {
				if (transform.rotation.z < maxRotation) {
					Quaternion deltaRotation = Quaternion.Euler ((new Vector3 (0.0f, 0.0f, 1.0f)) * rotationSpeed);
					rb.MoveRotation(rb.rotation * deltaRotation);
				}
			} 
			else {
				if (transform.rotation.z > -maxRotation) {
					Quaternion deltaRotation = Quaternion.Euler ((new Vector3 (0.0f, 0.0f, 1.0f)) * -rotationSpeed);
					rb.MoveRotation(rb.rotation * deltaRotation);
				}
			}
			zRotation = transform.eulerAngles.z;
		}
		//*/

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

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pitfall")) {
			gameObject.SetActive (false);
			infoPanel.SetActive (true);
			deathText.SetActive (true);
		}

		if (other.gameObject.CompareTag ("Goal")) {
            moveHorizontal = 0.0f;
			levelComplete = true;
			infoPanel.SetActive (true);
			winText.SetActive (true);
		}
	}

	void Flip(){
		facingRight = !facingRight;
		transform.RotateAround(transform.position, transform.up, 180f);
	}
}
