using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class castleNextLevelScript : MonoBehaviour {

	public GameObject castle;
	public GameObject peach;
	
	// Update is called once per frame
	void Update () 
	{
		if ((peach.transform.position.x + 1.3f >= castle.transform.position.x) && (peach.transform.position.y + 10.3f >= castle.transform.position.y) &&
		    (peach.transform.position.x - 1.3f <= castle.transform.position.x) && (peach.transform.position.y - 10.3f <= castle.transform.position.y))
		{
			SceneManager.LoadScene ("level2");
		}
	}
}
