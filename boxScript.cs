using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour 
{
	bool facingRight = false;
	public GameObject box;
	public GameObject bowser;
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			facingRight = false;
		}

		//change bowser's forward direction if press right 
		if (Input.GetKeyDown (KeyCode.RightArrow))
	   	{
			facingRight = true;
		}

		//checks if the flame is lit by checking for down arrow pressed
		if (Input.GetKeyDown (KeyCode.DownArrow) && facingRight == true)
		{
			//checks if box and flame collide 
			if (box.transform.position.x <= bowser.transform.position.x + 6 && box.transform.position.x >= bowser.transform.position.x) 
			{
				Destroy (box);
			}
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) && facingRight == false)
		{
			//checks if box and flame collide 
			if (box.transform.position.x <= bowser.transform.position.x && box.transform.position.x >= bowser.transform.position.x - 6) 
			{
				Destroy (box);
			}
		}
	}
}