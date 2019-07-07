using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickBlockScript : MonoBehaviour {

	int i = 0;
	public GameObject peach;
	public GameObject usedBrickBlock;
	public GameObject brickBlock;
	public GameObject coin;
	//float velocityX = 0;
	//float velocityY = 0;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update ()
	{
		if ((peach.transform.position.x + 0.5f >= brickBlock.transform.position.x) && (peach.transform.position.y - 0.0f <= brickBlock.transform.position.y) &&
			(peach.transform.position.x - 0.5f <= brickBlock.transform.position.x) && (peach.transform.position.y + 2.0f >= brickBlock.transform.position.y)) 
		{
			if (i < 1) {
				//Instantiate (coin, brickBlock.transform.position - new Vector3 (0, -2f, 0), Quaternion.identity);
				Instantiate (coin, brickBlock.transform.position - new Vector3 (0, 2f, 0), Quaternion.identity);
				//velocityY = velocityY + -0.1f;
				i++;
			} 
			else 
			{
				Instantiate (usedBrickBlock, brickBlock.transform.position, Quaternion.identity);
				Destroy (brickBlock);
			}
		}
		//coin.transform.Translate(velocityX, velocityY, 0);
	}
}
