using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowserControler : MonoBehaviour {

	public AudioClip flameSound;

	//movement variables
	float bowserXspeed = 0f;
	float bowserYspeed = 0f;
	bool facingRight = true;
	float gravity = 0.02f;
	bool isGrounded;

	//flame variables
	public GameObject flame;
	public GameObject bowser;
	GameObject flameClone;

	public GameObject camera;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{

		AudioSource sound = bowser.GetComponent<AudioSource> ();
		//move bowser forward if press left or right
		if (((Input.GetKey (KeyCode.LeftArrow)) && !(Input.GetKey (KeyCode.DownArrow))) || (Input.GetKey (KeyCode.RightArrow)) && !(Input.GetKey (KeyCode.DownArrow)))
		{

			bowserXspeed = -0.05f;
		} 
		else 
		{
			
			bowserXspeed = 0.00f;
		}

		//change bowser's forward direction if press left
		if ((facingRight == true ) && (Input.GetKeyDown (KeyCode.RightArrow)))
		{
			transform.Rotate (0, 180, 0);
			facingRight = false;
		}

		//change bowser's forward direction if press right 
		if ((facingRight == false) && (Input.GetKeyDown (KeyCode.LeftArrow)))
		{
			transform.Rotate (0, 180, 0);
			facingRight = true;
		}

		//checks if on ground
		RaycastHit2D hit = Physics2D.Raycast (transform.position - new Vector3(0,1.0f,0), -Vector2.up, 0.001f);
		if(hit.collider != null)	
		{
			isGrounded = true;
		}



		//jump with up arrow held
		if (Input.GetKey (KeyCode.UpArrow) && (isGrounded == true)) 
		{
			bowserYspeed = bowserYspeed + 0.3f;
			isGrounded = false;
			//sound.Play();
		}

		if (bowserYspeed >= -0.02f) 
		{
			bowserYspeed = bowserYspeed - gravity;
		}

		//actually move bowser left/right up/down
		transform.Translate(bowserXspeed, bowserYspeed, 0f);




		//if (Input.GetKeyUp (KeyCode.DownArrow))
		//{
			//in progress
		//	Destroy(flameClone);
		//}

		camera.transform.position = (bowser.transform.position + new Vector3 (0, 0, -10));

	}
}
