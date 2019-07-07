using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class controls the goombas movement and interactions with walls and peach.
//goomba walks right until it hits a wall then walks left until it hits another wall and repeats indefinetly.
//If goomba walks into peach which means peach is in the direction goomba is walking then both peach and the camera move to the start aka the origin
//If goomba is directly below peach then that goomba is destroyed
//goomba can also walk up and down some hills

public class goombaControler : MonoBehaviour {
	// Use this for initialization
	public GameObject goomba2;
	public GameObject peach;
	public GameObject camera;
	public GameObject coin;
	bool goingRight = true;

	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		//add this to add bounce
		//transform.Translate (0, 0.03f, 0);

		RaycastHit2D hit;


		hit = Physics2D.Raycast (transform.position + new Vector3(0, 0.6f,0), Vector2.up, 0.1f, -8);
		if(hit.collider != null)	
		{
			Instantiate (coin, goomba2.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}

			if (goingRight == true) {
			transform.Translate (0.03f, 0, 0);
			hit = Physics2D.Raycast (transform.position + new Vector3 (0.35f, 0, 0), Vector2.right, 0.1f);
			if (hit.collider != null) {
				goingRight = false;
				transform.Rotate (0, 180, 0);
			}
		}
			if (goingRight == true) 
			{
				hit = Physics2D.Raycast (transform.position + new Vector3 (0.35f, 0, 0), new Vector2 (0.1f, 0.3f), 0.1f, -8);
				if (hit.collider != null)
				{
					gameObject.transform.position = goomba2.transform.position + new Vector3 (0.01f, 0.08f, 0);
				}
			}

		if (goingRight == false) {
			transform.Translate (0.03f, 0, 0);
			hit = Physics2D.Raycast (transform.position + new Vector3 (-0.35f, 0, 0), -Vector2.right, 0.1f);
			if (hit.collider != null) {
				goingRight = true;
				transform.Rotate (0, 180, 0);
			}
		}
		hit = Physics2D.Raycast (transform.position + new Vector3 (0.45f, 0, 0), Vector2.right, 0.05f, -8);
		if ((hit.collider != null) && (goingRight == true)) 
		{
			peach.transform.position = new Vector3 (0, 0, 0);
			camera.transform.position = new Vector3 (0, 0, -10);
		}

		hit = Physics2D.Raycast (transform.position - new Vector3 (0.45f, 0, 0), Vector2.left, 0.05f, -8);
		if ((hit.collider != null) && (goingRight == false)) 
		{
			peach.transform.position = new Vector3 (0, 0, 0);
			camera.transform.position = new Vector3 (0, 0, -10);
		}
	}
}
