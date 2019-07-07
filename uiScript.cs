using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class controls the display of information such as the number of coins collected, number of lives left, and current level name and number


public class uiScript : MonoBehaviour {

	public Text coinCounter;
	public static int coinCount;
	public GameObject peach;
	public GameObject coin;
	public AudioClip coinSound;
	public GameObject SpecialPeachCoin;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		AudioSource sound = SpecialPeachCoin.GetComponent<AudioSource> ();
		//if peach and coin collide then coin count increases by 1
		//displays coinCount

		if ((peach.transform.position.x + 0.3 >= coin.transform.position.x) && (peach.transform.position.y + 0.3 >= coin.transform.position.y) &&
			(peach.transform.position.x - 0.3 <= coin.transform.position.x) && (peach.transform.position.y - 0.4 <= coin.transform.position.y)) 
		{
			sound.clip = coinSound;
			sound.Play();
			coinCount = coinCount + 1;
			Destroy (coin);
			coinCounter.text = "coins = " + coinCount;
		}


	}
}
