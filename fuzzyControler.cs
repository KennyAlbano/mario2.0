using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuzzyControler : MonoBehaviour {

	public GameObject camera;
	public GameObject peach;
	public GameObject fuzzy;
	float velocityX;
	float velocityY;
	bool isGrounded;
	float velocity = 0f;
	float gravity;

	// Use this for initialization
	void Start () 
	{
		gravity = 0.02f;
		velocityY = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if fuzzy is grounded then set velocity to go up
		RaycastHit2D hit = Physics2D.Raycast (transform.position - new Vector3(0,0.35f,0), -Vector2.up, 0.1f);
		if (hit.collider != null)
		{
			isGrounded = true;
		}
		else
		{
			isGrounded = false;
		}
		//set gravity
		if (velocityY >= -0.02f)
		{
			velocityY = velocityY - gravity;
		}

		if (isGrounded == true)
		{
			velocityY = velocityY + 0.03f;
			isGrounded = false;
		}



		//fuzzy follows the players x coordinate if the player is near by
		//fuzzy goes right
		if ((fuzzy.transform.position.x <= peach.transform.position.x)) 
		{
			velocityX = 0.01f;
		}

		//fuzzy goes left
		if ((fuzzy.transform.position.x >= peach.transform.position.x)) 
		{
			velocityX = -0.01f;
		}


		transform.Translate(velocityX, velocityY, 0);


		if ((peach.transform.position.x + 1.0f >= fuzzy.transform.position.x) && (peach.transform.position.y + 1.0 >= fuzzy.transform.position.y) &&
		    (peach.transform.position.x - 1.0f <= fuzzy.transform.position.x) && (peach.transform.position.y - 1.0 <= fuzzy.transform.position.y)) 
		{
			peach.transform.position = new Vector3 (0, 0, 0);
			camera.transform.position = new Vector3 (0, 0, -10);
		}

	}
}
