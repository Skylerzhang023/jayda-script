using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class main_button : MonoBehaviour {
	public AudioSource audiohover;
	public AudioSource click;
	public string sceneName;
	// Use this for initialization
	void Start () {

	}
	public void OnClickButton()  
	{  
		click.Play ();
		Debug.Log("button ok");
		Application.LoadLevel (0);
	} 
	// Update is called once per frame
	void Update () {

	}
}