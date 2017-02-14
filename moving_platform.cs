using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_platform : monster_basic {
	public Vector3 pos;
	public bool isplayer;
	public Control player;
	// Use this for initialization
	void Start () {
		walkstate = 1;
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Player") {
			isplayer = true;
			//print ("1");
		}
	}
	void OnCollisionExit2D(Collision2D col){
		isplayer = false;
	}
	// Update is called once per frame
	void Update () {
		pos = this.transform.position;
		if (walkstate == 1) {
			if (pos.x > -8) {
				if(isplayer){
					player.onplateform();
				}
						
				transform.Translate (Vector2.left * 0.1f);
			} 
			else {
				walkstate = 2;
			}
		}
		//pos = this.transform.position;
		if (walkstate == 2) {

			if (pos.x <8) {
				if(isplayer){
					player.onplatformr();
				}
				transform.rotation = Quaternion.AngleAxis (180, Vector3.down);
				transform.Translate (Vector2.left * 0.1f);
			} 
			else {
				//print ("here");
				transform.rotation = Quaternion.AngleAxis (0, Vector3.down);
				walkstate = 1;
				test = 2;
			}
		}

	}
}

