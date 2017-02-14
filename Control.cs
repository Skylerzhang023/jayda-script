using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour {
	public float jumpheight ;
	public float speed = 2.5f;
	public float jumptime = 0.00005f;
	public Transform player;
	public Animator anim;
	public bool grounded = true;
	public bool jumpstate;
	public float score;
	public GameObject good,clone;
	public AudioSource jump,get;
	public bool faceright;
	Vector3 pos;
	public spaceship ship;
	public fallingstone stone;

	// Use this for initialization
	void Start () {
		jumpstate = false;
		anim = GetComponent<Animator>();
		score = 0f;
		faceright = false;
	}
	public void hurt(){
		anim.Play("hurt");
	}
	public void onplatformr(){
		if(faceright){
			transform.Translate (Vector2.left* 0.2f);
		}
			
		transform.Translate (Vector2.right* 0.1f);
	}
	public void onplateform(){
		if(faceright){
			transform.Translate (Vector2.right* 0.2f);
		}
		transform.Translate (Vector2.left * 0.1f);
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		//anim.Stop ();
		if (col.gameObject.name == "rground" || col.gameObject.name == "bed" || col.gameObject.name == "bookshelter"||col.gameObject.name == "pillow"||col.gameObject.name == "cloud")
		{
			anim.Play ("walk");
			grounded = true;
			if (jumpstate == true) {
				//print ("ok");
				//anim.Stop ();
				//anim.Play ("walk");
			}
			jumpstate = false;
			//Debug.Log("I'm colliding with something!");
			//anim.Play ("walk");
		}
		if (col.gameObject.name == "good" || col.gameObject.name == "Star") {
			
			//print ("eat");
			//score += 1.0f;
			get.Play ();
			Destroy (col.gameObject);
			}


	}
	void OnTriggerEnter2D(Collider2D Coll)
	{
		print ("ok");
		if (Coll.gameObject.name == "good" || Coll.gameObject.name == "Star") {
			score += 1.0f;
			get.Play ();
			Destroy (Coll.gameObject);

		} else if (Coll.gameObject.name == "moon") {
			Application.LoadLevel (2);
		}
	}
	public float getscore()
	{
		return score;
	}
	// Update is called once per frame
	void Update () {
		pos = this.transform.position;
		if (pos.y > 35) {
			ship.active ();

		}
		if (pos.y > 38) {
			stone.active ();
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			faceright = false;
			transform.Translate(Vector2.left * Time.deltaTime*speed); //Go left
			transform.rotation = Quaternion.AngleAxis(0, Vector3.down);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{	
			faceright = true;
			transform.rotation = Quaternion.AngleAxis(180, Vector3.down);
			transform.Translate(Vector2.left * Time.deltaTime*speed); //Go right

		}
		if (Input.GetKey(KeyCode.UpArrow)) 
		{
			jumpstate = true;
			if(grounded==true){
				anim.Play("jump");
				transform.Translate(Vector2.up * jumpheight); //go up

			}
			jump.Play ();
			grounded = false;

			//transform.Translate(Vector2.up * jumptime);//Jump
		}

		if (Input.GetKeyDown(KeyCode.Q))
		{
			jumpstate = true;
			if(grounded==true){
				anim.Play("jump");
				transform.Translate(Vector2.up * jumpheight); //go up

			}
			jump.Play ();
			grounded = false;

			//transform.Translate(Vector2.up * jumptime);//Jump
		}

		
	}
}
