using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {
	public GameObject first, second, third, fourth;
	private List<GameObject> slides;
	private List<string> instructions;
	// Use this for initialization
	void Start () {
		slides = new List<GameObject> ();
		second.GetComponent<Renderer> ().enabled = false;
		third.GetComponent<Renderer> ().enabled = false;
		fourth.GetComponent<Renderer> ().enabled = false;
		slides.Add (first);
		slides.Add (second);
		slides.Add (third);
		slides.Add (fourth);

		instructions = new List<string> ();
		GameObject.Find("TutorialText").GetComponent<GUIText>().text = "Welcome to Shopper Express!";
		instructions.Add ("You need to be within budget! so make sure you keep an eye on it!");
		instructions.Add ("You also need to buy certain items within your budget!");
		instructions.Add ("Make sure you know the different Items!");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			if (this.transform.name == "NextText") {
				if (slides.Count > 1) {
					slides [0].GetComponent<Renderer> ().enabled = false;
					slides.RemoveAt (0);
					slides [0].GetComponent<Renderer> ().enabled = true;
					GameObject.Find ("TutorialText").GetComponent<GUIText> ().text = instructions [0];
					instructions.RemoveAt (0);
					if (slides.Count == 1) {
						Destroy (GameObject.Find ("SkipText"));
						gameObject.GetComponentInParent<GUIText> ().text = "Play";
					}
				} else {
					SceneManager.LoadScene ("mainScene");
				}
			}
			if (this.transform.name == "SkipText")
				SceneManager.LoadScene ("mainScene");
		}
	}
}