using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("Reflector")) {
			//Vector3 reflectedAngle = Vector3.Reflect (rb.transform.up, other.transform.up);
			//Quaternion deltaRotation = Quaternion.Euler(reflectedAngle * Time.deltaTime);
			//rb.MoveRotation(rb.rotation * deltaRotation);

			//rb.MoveRotation(new Quaternion(0.0f, 0.0f, reflectedAngle.z, 0.0f));

			//transform.eulerAngles = reflectedAngle;

			//transform.eulerAngles = new Vector3(0.0f, 0.0f, angle);
			return;
		}
		else
			Destroy (gameObject);
	}
}
