using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// used to control speed. By making this variable public this variable will show up in the inspector as a editable property. 
	public float speed;

	//variable used to hold the Rigidbody component reference.
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Called before performing any physics compilations
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");


		// Vector3 is (x, y, z)
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
  	if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
		}
  }
}