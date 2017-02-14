using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fly_monster : monster_basic {
	public GameObject BowlingBallSprite;
	public bool isnew;
	public Control player;
	bool kill;
	GameObject temp;
	float score;

	void Start () {
		isnew = true;
		kill = false;
	}

	public void Falldown(){
		//print (Random.Range (1, 10));
		if (Random.Range (1, 10) > 8) {
			//print ("ok");
			transform.Translate (Vector2.down * 0.1f);
		}
	}

	IEnumerator load()
	{
		yield return new WaitForSeconds(3);    //注意等待时间的写法
	}
	void OnTriggerEnter2D(Collider2D Coll)
	{
		//print(Coll.gameObject.name) ; 
		print ("ok");
		if (Coll.gameObject.name == "Player") {
			player.hurt ();
			temp = Coll.gameObject;
			StartCoroutine(load()); 
			hit.Play ();
			StartCoroutine(wait());
		}
	}
	// Update is called once per frame
	void Update () {
		
		if (kill) {
			score = player.getscore ();
			PlayerPrefs.SetFloat("score",score);
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
		Falldown ();
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
