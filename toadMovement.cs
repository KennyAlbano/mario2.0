using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toadMovement : MonoBehaviour {

	public GameObject toad;
	bool hitWall = false;

	// Update is called once per frame
	void Update () 
	{
		//if hit wall rotate 180 degrees
		//always move forward

		toad.transform.Translate (0.1f, 0, 0);

		RaycastHit2D hit;
		hit = Physics2D.Raycast (toad.transform.position + new Vector3(0.5f, 0,0), Vector2.right, 0.1f);
		if (hit.collider != null) 
		{
			hitWall = true;
		}

		hit = Physics2D.Raycast (toad.transform.position + new Vector3(-0.5f, 0,0), Vector2.right, 0.1f);
		if (hit.collider != null) 
		{
			hitWall = true;
		}

		if (hitWall == true) 
		{
			toad.transform.Rotate (0, 180, 0);
			hitWall = false;
		}			
	}
}