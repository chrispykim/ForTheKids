using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	public int score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			print (score);
			SceneManager.LoadScene ("testBegin");
		}
	}
}
