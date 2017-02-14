using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingstone : monster_basic {
	bool kill;
	GameObject temp;
	float score;
	public void fall()
	{
		transform.Translate (Vector2.down * 0.02f);
	}
	public void active()
	{
		walkstate = 1;
	}
	// Use this for initialization
	void Start () {
		kill = false;
	}

	void OnTriggerEnter2D(Collider2D Coll)
	{
		//print(Coll.gameObject.name) ; 
		print ("ok");
		if (Coll.gameObject.name == "Player") {
			player.hurt ();
			temp = Coll.gameObject;
			hit.Play ();
			StartCoroutine(wait());
		}
	}
	// Update is called once per frame
	void Update () {
		score = player.getscore ();
		PlayerPrefs.SetFloat("score",score);
		if (kill) {
			Destroy (temp);
			Application.LoadLevel (3);
		}
		if (pos.y < -4) {
			//Destroy ();
			//if (isnew==true) {
			//	isnew = false;
			//	Instantiate (BowlingBallSprite, new Vector3 (-7, 4, 0), Quaternion.identity);
			//}
		}
		pos = this.transform.position;
		if (walkstate == 1 || walkstate == 2) {
			fall ();
		}
		if (walkstate == 1) {
			if (pos.x > -8) {
				if (test == 2) {
				}
				transform.Translate (Vector2.left * 0.1f);
			} 
			else {
				walkstate = 2;
			}
		}
		//pos = this.transform.position;
		if (walkstate == 2) {

			if (pos.x < 8) {
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
