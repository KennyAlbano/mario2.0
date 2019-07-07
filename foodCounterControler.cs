using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class foodCounterControler : MonoBehaviour {

	bool stopThrowing = false;
	bool facingRight = true;
	public GameObject peach;
	public GameObject peachFood;
	public static int foodCount;
	public Text foodCounter;
	public GameObject specialFood;
    GameObject throwing;
	bool wasFacingRight = true;

	public GameObject goomba1;
	public GameObject goomba2;
	public GameObject goomba3;
	public GameObject goomba4;
	public GameObject goomba5;
	public GameObject goomba6;
	public GameObject goomba7;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
		//if press left button move left
		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			facingRight = false;
		}
		//if press right button move right
		if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			facingRight = true;
		}


		if ((peach.transform.position.x + 1.3f >= peachFood.transform.position.x) && (peach.transform.position.y + 1.3f >= peachFood.transform.position.y) &&
			(peach.transform.position.x - 1.3f <= peachFood.transform.position.x) && (peach.transform.position.y - 1.3f <= peachFood.transform.position.y))
		{
			Destroy (peachFood);
			foodCount = foodCount + 1;
			foodCounter.text = "food = " + foodCount;
		}

		//if foodCount is greater than or equal to 1 and player presses spacebar key then throw food in direction peach is facing and decrease foodCount by 1
		if (foodCount >= 1 && Input.GetKeyDown(KeyCode.DownArrow))
		{
			if (facingRight == true) 
			{
				throwing = Instantiate (specialFood, peach.transform.position + new Vector3 (0.3f, -0.3f, 0), Quaternion.identity);
				wasFacingRight = true;
			} 
			else
			{
				throwing = Instantiate (specialFood, peach.transform.position + new Vector3 (-0.3f, -0.3f, 0), Quaternion.identity);
				wasFacingRight = false;

			}
			foodCount = foodCount - 1;
			foodCounter.text = "food = " + foodCount;

		}
		RaycastHit2D hit;
		if (wasFacingRight == true) 
		{
			hit = Physics2D.Raycast (throwing.transform.position + new Vector3 (0.271f, 0f, 0), Vector2.right, 0.001f);
		} 
		else
		{
			hit = Physics2D.Raycast (throwing.transform.position + new Vector3 (-0.271f, 0f, 0), Vector2.right, -0.001f);

		}
		if(hit.collider == null && stopThrowing == false)	
		{
			if (wasFacingRight == true) {
				throwing.transform.Translate (0.1f, -0f, 0);
			} 
			else
			{
				throwing.transform.Translate (-0.1f, 0f, 0);

			}
		}
		if (hit.collider != null) 
		{
			//if (hit.gameObject.tag == "goomba") 
			//{
				//Destroy (gameObject.tag.goomba);
			//}
			//stopThrowing = true;
			Destroy (throwing);
		}
		if ((goomba1.transform.position.x + 1.3f >= throwing.transform.position.x) && (goomba1.transform.position.y + 1.3f >= throwing.transform.position.y) &&
		    (goomba1.transform.position.x - 1.3f <= throwing.transform.position.x) && (goomba1.transform.position.y - 1.3f <= throwing.transform.position.y)) 
		{
			Destroy (goomba1);
			Destroy (throwing); 
		}
		if ((goomba2.transform.position.x + 1.3f >= throwing.transform.position.x) && (goomba2.transform.position.y + 1.3f >= throwing.transform.position.y) &&
			(goomba2.transform.position.x - 1.3f <= throwing.transform.position.x) && (goomba2.transform.position.y - 1.3f <= throwing.transform.position.y)) 
		{
			Destroy (goomba2);
			Destroy (throwing); 
		}
		if ((goomba3.transform.position.x + 1.3f >= throwing.transform.position.x) && (goomba3.transform.position.y + 1.3f >= throwing.transform.position.y) &&
			(goomba3.transform.position.x - 1.3f <= throwing.transform.position.x) && (goomba3.transform.position.y - 1.3f <= throwing.transform.position.y)) 
		{
			Destroy (goomba3);
			Destroy (throwing); 
		}
		if ((goomba4.transform.position.x + 1.3f >= throwing.transform.position.x) && (goomba4.transform.position.y + 1.3f >= throwing.transform.position.y) &&
			(goomba4.transform.position.x - 1.3f <= throwing.transform.position.x) && (goomba4.transform.position.y - 1.3f <= throwing.transform.position.y)) 
		{
			Destroy (goomba4);
			Destroy (throwing); 
		}
		if ((goomba5.transform.position.x + 1.3f >= throwing.transform.position.x) && (goomba5.transform.position.y + 1.3f >= throwing.transform.position.y) &&
			(goomba5.transform.position.x - 1.3f <= throwing.transform.position.x) && (goomba5.transform.position.y - 1.3f <= throwing.transform.position.y)) 
		{
			Destroy (goomba5);
			Destroy (throwing); 
		}
		if ((goomba6.transform.position.x + 1.3f >= throwing.transform.position.x) && (goomba6.transform.position.y + 1.3f >= throwing.transform.position.y) &&
			(goomba6.transform.position.x - 1.3f <= throwing.transform.position.x) && (goomba6.transform.position.y - 1.3f <= throwing.transform.position.y)) 
		{
			Destroy (goomba6);
			Destroy (throwing); 
		}
		if ((goomba7.transform.position.x + 1.3f >= throwing.transform.position.x) && (goomba7.transform.position.y + 1.3f >= throwing.transform.position.y) &&
			(goomba7.transform.position.x - 1.3f <= throwing.transform.position.x) && (goomba7.transform.position.y - 1.3f <= throwing.transform.position.y)) 
		{
			Destroy (goomba7);
			Destroy (throwing); 
		}


	}
}
