using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer_controller : MonoBehaviour {
	float gameTime;
	public Text timerText;

	// Use this for initialization
	void Start () {
		gameTime = 0f;
		timerText.text = gameTime.ToString () + "s";
	}
	
	// Update is called once per frame
	void Update () {
		gameTime = gameTime + Time.deltaTime;
		int newGameTime = (int)gameTime;
		timerText.text = newGameTime.ToString () + "s";


	}
}
