using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// used to control speed. By making this variable public this variable will show up in the inspector as a editable property. 
	public float speed;

  //Used for UI count text
  public Text countText;

  //Used to show win text
  public Text winText;

	//variable used to hold the Rigidbody component reference.
	private Rigidbody rb;

  //Used to hold collectible count.
  private int count;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
    count = 0;
    SetCountText();
    winText.text = "";
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
      count++;
      SetCountText();
		}
  }

  void SetCountText()
  {
    countText.text = "Count: " + count.ToString();
    if (count >= 12)
    {
      winText.text = "You win!";
    }
  }
}