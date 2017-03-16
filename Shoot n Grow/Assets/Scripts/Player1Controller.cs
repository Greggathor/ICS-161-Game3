using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Controller : MonoBehaviour {
	
	private Rigidbody rb;
	private SphereCollider sc;
	private Vector3 spawnpoint;
	public bool checkpoint = false;

	private bool jump = false;
	public float jumpForce;
	public float gravity;
	private bool grounded;
	public Transform groundCheck1;
	public Transform groundCheck2;
    public Transform groundCheck3;

	public float moveHorizontal = 0.0f;
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
	//public float shrinkSize;
	public float shrinkRate;
	private bool revertToNormal;
	private bool narrowSpace = false;

	public bool levelComplete = false;

	public GameObject infoPanel;
	public GameObject winText;
	public GameObject deathText;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		sc = GetComponent<SphereCollider> ();
		spawnpoint = transform.position;
	}

	void Update(){
		if (levelComplete) {
			if(Input.GetKey(KeyCode.Return))
				SceneManager.LoadScene ((SceneManager.GetActiveScene ().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
			return;
		}

		grounded = Physics.Linecast (transform.position, groundCheck1.position, 1 << LayerMask.NameToLayer ("Ground"))
			|| Physics.Linecast (transform.position, groundCheck2.position, 1 << LayerMask.NameToLayer ("Ground"))
            || Physics.Linecast (transform.position, groundCheck3.position, 1 << LayerMask.NameToLayer ("Ground"));

        //grounded = Physics.Linecast(groundCheck1.position, groundCheck2.position, 1 << LayerMask.NameToLayer ("Ground"));
        //Debug.DrawLine(groundCheck1.position,groundCheck2.position,Color.red);

		if (Input.GetKeyDown(KeyCode.Space) && grounded) {
		//if (Input.GetKeyDown(KeyCode.RightControl) && grounded) {
			jump = true;
		}

		if (Input.GetKey (KeyCode.D)) {
			moveHorizontal = speed;
		}
		else if (Input.GetKey (KeyCode.A)) {
			moveHorizontal = -speed;
		}
		else {
			moveHorizontal = 0.0f;
		}

		if(Input.GetKeyDown(KeyCode.W)){
			if(!wideForm){
				tallForm = true;
				sc.enabled = false;
				//transform.localScale = new Vector3 (1.0f, 3.0f, 1.0f);
			}
		}

		if(Input.GetKeyDown(KeyCode.S)){
			if(!tallForm){
				wideForm = true;
				sc.enabled = false;
				//transform.localScale = new Vector3 (3.0f, 1.0f, 1.0f);
			}
		}

		if(tallForm && Input.GetKeyUp(KeyCode.W)){
			revertToNormal = true;
		}

		if(wideForm && Input.GetKeyUp(KeyCode.S)){
			revertToNormal = true;
		}

		if (!grounded && sc.enabled == true) {
			sc.enabled = false;
		}

		if (sc.enabled == false && grounded && !(tallForm || wideForm)) {
			sc.enabled = true;
		}

        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;

        //Only shows cursors in main menu
        if(sceneName != "MainMenu")
            Cursor.visible = false;
        else
            Cursor.visible = true;
	}

	void FixedUpdate () {
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		rb.AddForce (movement, ForceMode.VelocityChange);

		if (moveHorizontal > 0 && !facingRight)
			Flip ();
		else if (moveHorizontal < 0 && facingRight)
			Flip ();

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
				width -= shrinkRate;
				transform.localScale = new Vector3(width, height, 1.0f);
			}
			//if (Input.GetKeyUp (KeyCode.W)) {
			if(revertToNormal && !narrowSpace){
				revertToNormal = false;
				tallForm = false;
				height = 1.0f;
				width = 1.0f;
				transform.localScale = new Vector3(width, height, 1.0f);
				sc.enabled = true;	
			}
		}
		if (wideForm) {
			if (width < maxWidth) {
				width += growthRate;
				height -= shrinkRate;
				transform.localScale = new Vector3(width, height, 1.0f);
			}
			//if (Input.GetKeyUp (KeyCode.S)) {
			if(revertToNormal && !narrowSpace){
				revertToNormal = false;
				wideForm = false;
				width = 1.0f;
				height = 1.0f;
				transform.localScale = new Vector3(width, height, 1.0f);
				sc.enabled = true;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pitfall")) {
            //Vector3 player2 = GameObject.Find("Player2").transform.position;
            //transform.position = new Vector3 (player2.x, player2.y + 1.5f, player2.z);
			transform.position = new Vector3 (spawnpoint.x, spawnpoint.y, spawnpoint.z);

			HealthUI healthaccess = gameObject.GetComponent<HealthUI>();

			//decrement--;
            //healthaccess.health--;
            healthaccess.LoseHealth(1);

            if(healthaccess.health == 0)
            {
                GameObject playertwo = GameObject.Find("Player2");
                playertwo.SetActive(false);
                gameObject.SetActive (false);
                infoPanel.SetActive (true);
                deathText.SetActive (true);
            }
		}

		if(other.gameObject.CompareTag("Dangerous")){
			HealthUI healthaccess = gameObject.GetComponent<HealthUI>();
			healthaccess.LoseHealth(healthaccess.health);

			GameObject playertwo = GameObject.Find("Player2");
			playertwo.SetActive(false);
			gameObject.SetActive (false);
			infoPanel.SetActive (true);
			deathText.SetActive (true);
		}

		if (other.gameObject.CompareTag ("Goal")) {
            //GameObject playertwo = GameObject.Find("Player2");
            //Player2Controller twoaccess = playertwo.GetComponent<Player2Controller>();
            //twoaccess.moveHorizontal = 0.0f;
            moveHorizontal = 0.0f;
			levelComplete = true;
			infoPanel.SetActive (true);
			winText.SetActive (true);
		}

		if (other.gameObject.CompareTag ("NarrowSpace")) {
			narrowSpace = true;
		}

		if (other.gameObject.CompareTag ("Checkpoint")) {
			checkpoint = true;
			spawnpoint = other.transform.position;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("NarrowSpace")) {
			narrowSpace = false;
		}
	}

	void Flip(){
		facingRight = !facingRight;
		transform.RotateAround(transform.position, transform.up, 180f);
	}
}
