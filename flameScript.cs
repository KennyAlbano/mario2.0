using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameScript : MonoBehaviour {
	
	public GameObject flame;
	public static GameObject flameClone;
	bool facingRight = false;
	public GameObject bowser;
	public static int flameCount = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () 
	{

		if ((facingRight == true ) && (Input.GetKeyDown (KeyCode.LeftArrow)))
		{
			facingRight = false;
		}

		//change bowser's forward direction if press right 
		if ((facingRight == false) && (Input.GetKeyDown (KeyCode.RightArrow)))
		{
			facingRight = true;
		}

		//if press down shoot fire in direction bowser is facing
		if (Input.GetKeyDown (KeyCode.DownArrow) && flameCount <= 0)
		{
			flameCount = flameCount + 1;
			if (facingRight == true)
			{
				flameClone = Instantiate (flame, bowser.transform.position + new Vector3 (3f, 0, -1), Quaternion.identity);
			}
			else 
			{
				flameClone = Instantiate (flame, bowser.transform.position + new Vector3 (-3f, 0, -1), Quaternion.identity);
				flameClone.transform.Rotate (0, 180, 0);
			}
		}
		if (Input.GetKeyUp (KeyCode.DownArrow))
		{
			//in progress
			Destroy(flameClone);
			flameCount = flameCount - 1;
		}


	}
}


