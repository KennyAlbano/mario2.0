using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableBoxScript : MonoBehaviour {

	bool box4Exists = true;
	bool box3Exists = true;
	bool box2Exists = true;
	bool box1Exists = true;
	public GameObject box1;
	public GameObject box2;
	public GameObject box3;
	public GameObject box4;
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


		//if breakableBox and flame collide then break box
		if (flameCount == 1 && box1Exists == true)
		{
			if (box1.transform.position.x - 3 <= flameClone.transform.position.x && box1.transform.position.x + 3 >= flameClone.transform.position.x) 
			{
				box1Exists = false;
				Destroy (box1);
			}
		}

		//if breakableBox and flame collide then break box
		if (flameCount == 1 && box2Exists == true)
		{
			if (box2.transform.position.x - 3 <= flameClone.transform.position.x && box2.transform.position.x + 3 >= flameClone.transform.position.x) 
			{
				box2Exists = false;
				Destroy (box2);
			}
		}



		//if breakableBox and flame collide then break box
		if (flameCount == 1 && box3Exists == true)
		{
			if (box3.transform.position.x - 3 <= flameClone.transform.position.x && box3.transform.position.x + 3 >= flameClone.transform.position.x) 
			{
				box3Exists = false;
				Destroy (box3);
			}
		}

		//if breakableBox and flame collide then break box
		if (flameCount == 1 && box4Exists == true)
		{
			if (box4.transform.position.x - 3 <= flameClone.transform.position.x && box4.transform.position.x + 3 >= flameClone.transform.position.x) 
			{
				box4Exists = false;
				Destroy (box4);
			}
		}

		//if press down shoot fire in direction bowser is facing
		if (Input.GetKeyDown (KeyCode.DownArrow) && flameCount <= 0)
		{
			flameCount = flameCount + 1;
			if (facingRight == true)
			{
				flameClone = Instantiate (flame, bowser.transform.position + new Vector3 (3f, 0, 0), Quaternion.identity);
			}
			else 
			{
				flameClone = Instantiate (flame, bowser.transform.position + new Vector3 (-3f, 0, 0), Quaternion.identity);
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


