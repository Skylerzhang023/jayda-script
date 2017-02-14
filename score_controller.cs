using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_controller : MonoBehaviour {
	float score;
	public Text showscore;
	public Control player;

	// Use this for initialization
	void Start () {
		score = 0;
		showscore.text = score.ToString ();

	}

	// Update is called once per frame
	void Update () {
		score = player.getscore();
		showscore.text = score.ToString();
	}
}
