using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_basic : MonoBehaviour {
	public Vector3 pos;
	public int walkstate,test;
	public Collider2D coll;
	public Control player;
	public AudioSource hit;
	public float node;
	bool kill;
	GameObject temp;
	float score;

	public IEnumerator wait()
	{
		yield return new WaitForSeconds(1.5f);
		kill = true;
	}

	void OnTriggerEnter2D(Collider2D Coll)
	{
		if (Coll.gameObject.name == "Player") {
			temp = Coll.gameObject;
			player.hurt ();     
			hit.Play ();
			node = Time.time;
			StartCoroutine(wait());
		}
	}


	void Start () {
		walkstate = 1;
		test = 1;
		kill = false;
		//Check if the isTrigger option on th Collider2D is set to true or false
	}

	// Update is called once per frame
	void Update () {
		pos = this.transform.position;
		if (kill) {
			score = player.getscore ();
			PlayerPrefs.SetFloat("score",score);  
			Destroy (temp);
			Application.LoadLevel (3);
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
				
				transform.rotation = Quaternion.AngleAxis (0, Vector3.down);
				walkstate = 1;
				test = 2;
			}
		}
	}
}
