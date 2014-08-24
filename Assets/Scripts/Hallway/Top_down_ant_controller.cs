﻿using UnityEngine;
using System.Collections;

public class Top_down_ant_controller : MonoBehaviour {

	public float speed = 2f;
	private Animator ant_animator;
	private Transform ant_transform;
	private Vector3 starting_position;
	// Use this for initialization
	void Start () {
		starting_position = transform.position;
		ant_transform = transform;
		ant_animator = transform.GetChild(0).GetComponent<Animator>(); //GetComponent<Animator> ();
		//ant_transform.Rotate (Vector3.forward * 90,Space.World);
		//ant_transform.rotation = Quaternion.AngleAxis (90f, Vector3.forward);
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	private void Move(){
		//allows movement in both up/down and right/left directions at same time, but does not allow up and down movement at the same time
		bool walking = false;
		if (Input.GetKey (KeyCode.RightArrow)) {
			ant_transform.Translate (Vector3.right * speed * Time.deltaTime);
			walking=true;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			ant_transform.Translate (-Vector3.right * speed * Time.deltaTime);
			walking=true;
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			ant_transform.Translate (-Vector3.up * speed * Time.deltaTime);
			walking=true;
		}else if (Input.GetKey(KeyCode.UpArrow)){
			ant_transform.Translate (Vector3.up * speed * Time.deltaTime);
			walking=true;
		}

		ant_animator.SetBool("walking",walking);
	}

	void OnCollisionEnter2D(Collision2D col){
		Debug.Log ("Collision");
		if(col.gameObject.tag!="level"){
			if(col.gameObject.tag=="end"){
				//end level
			}
			transform.position = starting_position;
		}
	}

}
