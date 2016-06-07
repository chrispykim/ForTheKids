using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	public int score;
	public bool gameOver;

	// Use this for initialization
	void Start () {
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0) && gameOver){
			print (score); // event manager from game scene updates this value upon exit. use for overworld
			SceneManager.LoadScene ("testBegin"); // loops back to tutorial. change to overworld
		}
	}
}
