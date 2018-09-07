using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//public GameObject reference to the player.
	public GameObject player;

	//private Vector3 offset value for camera relative to player.
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame like Update but guaranteed to run after all items have been processed in Update. Camera position is best used in LateUpdate.
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
