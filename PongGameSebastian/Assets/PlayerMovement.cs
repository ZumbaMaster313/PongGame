using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float speed = 0.1f;

	private Rigidbody2D rb2d;

	private bool movingUp;
	private bool movingDown;


	// Use this for initialization
	void Start () {

		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();

		movingUp = true;
		movingDown = true;
	}

	// Update is called once per frame
	void FixedUpdate () {

		float moveHorizontal = 0;
		float moveVertical = 0;


		//Checks to see if moving up
		if (Input.GetKeyDown ("up") || Input.GetKeyDown ("w")
			|| ((Input.GetKeyUp ("right") || Input.GetKeyUp ("d") || Input.GetKeyUp ("left") || Input.GetKeyUp ("a") || Input.GetKeyUp ("down") || Input.GetKeyUp ("s")) 
				&& (Input.GetKey ("up") || Input.GetKey ("w")))) {
			movingUp = true;
			movingDown = false;

		}

		//Checks to see if moving down
		if (Input.GetKeyDown ("down") || Input.GetKeyDown ("s")
			|| ((Input.GetKeyUp ("right") || Input.GetKeyUp ("d") || Input.GetKeyUp ("left") || Input.GetKeyUp ("a") || Input.GetKeyUp ("up") || Input.GetKeyUp ("w")) 
				&& (Input.GetKey ("down") || Input.GetKey ("s")))) {
			movingUp = false;
			movingDown = true;

		}


	

		if (movingUp || movingDown) {
			moveVertical = Input.GetAxis ("Vertical");
		} 


		//Store movement in a 2d vector
		Vector2 movement = new Vector2(moveHorizontal, moveVertical); 

		//move the player
		rb2d.MovePosition (rb2d.position + movement * speed * Time.deltaTime);
	}

}