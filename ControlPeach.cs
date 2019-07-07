using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class controls the movement of the player peach
//The left and right arrow keys move peach in their respective directions as long as the immediate location being moved into is collision free
//Peach constantly feels the force of gravity moveing her downwards until she collides with the ground. 
//In the game unlike real life gravity is constant velocity instead of constant acceleration
//To perform a single jump the player presses the up arrow once. 
//The player can also jump a second time by pressing the up arrow while in the air

public class ControlPeach : MonoBehaviour 
{
		//clears image background
	//www.online-image-editor.com
	//www.online-image-editor.com
	//www.online-image-editor.com


	//public GameObject goomba;
	bool facingRight = true;
	public GameObject peach;
	public GameObject camera;
	int numberOfJumps = 0;
	public bool isGrounded;
	float gravity;
	float velocityX = 0;
	float velocityY = 0;
	float speedBoost = 1;


	// Use this for initialization
	void Start () 
	{
		gravity = 0.02f;
	}

	// Update is called once per frame
	void Update () 
	{

		AudioSource sound = camera.GetComponent<AudioSource> ();

		if (peach.transform.position.y <= -10) 
		{
			peach.transform.position = new Vector3 (0, 0, 0);
			camera.transform.position = new Vector3 (0, 0, -10);
		}
		if (camera.transform.position.y > -8.5) 
		{
			camera.transform.position = (peach.transform.position + new Vector3 (0, 0, -10));
		}
		else
		{
			camera.transform.position = new Vector3 (peach.transform.position.x, -8.5f, -10f);
		}

		RaycastHit2D hit = Physics2D.Raycast (transform.position - new Vector3(0,0.7f,0), -Vector2.up, 0.001f);
		if(hit.collider != null)	
		{
			isGrounded = true;
		}
			
		//hit = Physics2D.Raycast (transform.position - new Vector3(0, 0.8f,0), -Vector2.up, 0.1f, -8);
		//if(hit.collider != null)	
		//{
		//	Destroy (goomba);
		//}


		//if press left button move left
		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			velocityX = -0.05f * speedBoost; 
			if (facingRight == false) 
			{
				peach.transform.Rotate (0, 180, 0);
				facingRight = true;
			}
		}
		//if press right button move right
		if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			velocityX = -0.05f * speedBoost; 
			if (facingRight == true) 
			{
				peach.transform.Rotate (0, 180, 0);
				facingRight = false;
			}
		}

		if (Input.GetKey (KeyCode.RightShift)) {
			speedBoost = 2f;
		} else 
		{
			speedBoost = 1;
		}

		if (!(Input.GetKey (KeyCode.LeftArrow)) && !(Input.GetKey (KeyCode.RightArrow)))
		{
			velocityX = 0f;
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) && ((velocityY <= 0.01f) && (numberOfJumps <= 1))) 
		{
			velocityY = velocityY + 0.3f;
			isGrounded = false;
			sound.Play();
		}

			
		if (velocityY >= -0.02f)
		{
			velocityY = velocityY - gravity;
		}

		//actually moves pech horizontally and vertically
		transform.Translate(velocityX, velocityY, 0);

		if (Input.GetKeyDown (KeyCode.UpArrow))
		{
			numberOfJumps = numberOfJumps + 1;
		}
		if (isGrounded == true)
		{
			numberOfJumps = 0;
		}

	}


}
