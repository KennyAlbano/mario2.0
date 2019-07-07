using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koopaScript : MonoBehaviour {

	public GameObject koopa;
	bool goingRight = true;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit;


	if (goingRight == true) 
	{
		koopa.transform.Translate (0.03f, 0, 0);
		hit = Physics2D.Raycast (transform.position + new Vector3 (1.35f, 0, 0), Vector2.right, 0.1f);
		if (hit.collider != null) 
		{
			goingRight = false;
			koopa.transform.Rotate (0, 180, 0);
		}
	 }

	if (goingRight == false) 
	{
		koopa.transform.Translate (0.03f, 0, 0);
		hit = Physics2D.Raycast (transform.position + new Vector3 (-1.35f, 0, 0), -Vector2.right, 0.1f);
		if (hit.collider != null)
		{
			goingRight = true;
			koopa.transform.Rotate (0, 180, 0);
		}
	}
}
}
