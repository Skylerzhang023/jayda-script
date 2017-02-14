using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class button : MonoBehaviour {
	public AudioSource audiohover;
	public AudioSource click;
	public string sceneName;
	// Use this for initialization
	void Start () {
		if (click == null)  
			Debug.LogError("没有绑定音效"); 
	}

	public void OnClickButton()  
	{  
		click.Play ();
		Debug.Log("button ok"); 
		Application.LoadLevel (1);
	} 
	// Update is called once per frame
	void Update () {
		
	}
}
