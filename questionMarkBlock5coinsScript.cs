using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is for the blocks with a question mark on them
//If peach jumps into this block from below 5 coins come out of the bottom and the block changes to a darker appearnce to show it is used up

public class questionMarkBlock5coinsScript : MonoBehaviour {

	int i = 0;
	public GameObject peach;
	public GameObject usedBlock;
	public GameObject questionMarkBlock;
	public GameObject coin;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((peach.transform.position.x + 0.5f >= questionMarkBlock.transform.position.x) && (peach.transform.position.y - 0.0f <= questionMarkBlock.transform.position.y) &&
			(peach.transform.position.x - 0.5f <= questionMarkBlock.transform.position.x) && (peach.transform.position.y + 1.0f >= questionMarkBlock.transform.position.y)) 
		{
			if (i < 5) {
				Instantiate (coin, questionMarkBlock.transform.position - new Vector3 (0, 1f, 0), Quaternion.identity);
				i++;
			} 
			else 
			{
				Instantiate (usedBlock, questionMarkBlock.transform.position, Quaternion.identity);
				Destroy (questionMarkBlock);
			}
		}





	}
}
