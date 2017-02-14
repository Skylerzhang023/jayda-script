using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose_player : MonoBehaviour {
	public Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		anim.Play("hurt");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
