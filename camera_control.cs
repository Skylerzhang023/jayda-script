using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class camera_control : MonoBehaviour {
	public Transform target;
	public float smothing = 5f;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
		offset.x = 0;
	}
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetCampos = target.position + offset;
		targetCampos.x = 0;
		if (target.position.y > -2.5f && target.position.y < 47) {
			transform.position = Vector3.Lerp (transform.position, targetCampos, smothing * Time.deltaTime);
		}
	 }
 }
