using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class win_score : MonoBehaviour {
	public Text showscore;
	public Control player;
	float score;

	// Use this for initialization
	void Start () {
		score = 0;
		showscore.text = score.ToString ();
	}

	// Update is called once per frame
	void Update () {
		score = player.getscore();
		score = PlayerPrefs.GetFloat("score");
		print(score);
		showscore.text =score.ToString ();
	}
}

