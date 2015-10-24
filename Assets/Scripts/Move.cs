﻿using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	float speed = 2.0f;
	protected Animator animator;
	float pop_clip_length = 0.0f;

//	private Vector3 finger_pos;
//	private Vector3 mouse_pos;
//	public float cam_dist = 2.3f;
//	public float smoothTime = 0.3f;

//	private float half_balloon_width = 0.75f;
//	private float half_balloon_height = 0.95f;
//	private float gameover_x = 0.1681508f;
//	private float gameover_y = 0.8318496f;

	public int score = 0;
	GUIText score_object;
	GUIText final_score_object;
	GameObject play_again;
	GameObject gameover;

	void Start() {
		gameover = GameObject.Find ("GameOver");
		play_again = GameObject.Find ("PlayAgain");
		if (gameover != null) {
			gameover.SetActive (false);
		}
		if (play_again != null) {
			play_again.SetActive (false);
		}
	
		animator = GetComponent<Animator>();
		score_object = GameObject.Find("Score").guiText;
		final_score_object = GameObject.Find("FinalScore").guiText;
	}

	void Update() {
		var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime;

//		if(Input.GetKeyDown(KeyCode.LeftArrow)) {
//			GameObject potato = GameObject.Find("Potato");
//			Bar bar_script = potato.GetComponent<Bar>();
//			bar_script.barDisplay -= 0.1f;
//		}

//		if (Input.touchCount >= 1) {
//			finger_pos =  Input.GetTouch(0).position;
//			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
//			var mouse_pos = ray.origin + (ray.direction * cam_dist);  
//			if (mouse_pos.y > transform.position.y + half_balloon_height &&
//			    mouse_pos.x > transform.position.x - half_balloon_width &&
//			    mouse_pos.x < transform.position.x + half_balloon_width) {
//				createPuffObject ("PuffDown", mouse_pos);
//				StartCoroutine (endPuff("PuffDown"));
//				
//				Vector3 movement = new Vector3(0.0f, - speed, 0.0f);
//				transform.position += movement * speed * Time.deltaTime;
//				
//			} else if (mouse_pos.y < transform.position.y - half_balloon_height && 
//			           mouse_pos.x > transform.position.x - half_balloon_width &&
//			           mouse_pos.x < transform.position.x + half_balloon_width) {
//
//					createPuffObject ("PuffUp", mouse_pos);
//					StartCoroutine (endPuff("PuffUp"));
//				
//				Vector3 movement = new Vector3(0.0f, speed, 0.0f);
//				transform.position += movement * speed * Time.deltaTime;
//			} else if (mouse_pos.x > transform.position.x + half_balloon_width && 
//			           mouse_pos.y > transform.position.y - half_balloon_height &&
//			           mouse_pos.y < transform.position.y + half_balloon_height) {
//				createPuffObject ("PuffLeft", mouse_pos);
//				StartCoroutine (endPuff("PuffLeft"));
//				
//				Vector3 movement = new Vector3(- speed, 0.0f, 0.0f);
//				transform.position += movement * speed * Time.deltaTime;
//				
//			} else if (mouse_pos.x < transform.position.x - half_balloon_width &&
//			           mouse_pos.y > transform.position.y - half_balloon_height &&
//			           mouse_pos.y < transform.position.y + half_balloon_height) {
//				createPuffObject ("PuffRight", mouse_pos);
//				StartCoroutine (endPuff("PuffRight"));
//				
//				Vector3 movement = new Vector3(speed, 0.0f, 0.0f);
//				transform.position += movement * speed * Time.deltaTime;
//			}
//		}

//		else if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0)) {
//
//			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);    
//			var mouse_pos = ray.origin + (ray.direction * cam_dist);  
//			if (mouse_pos.y > transform.position.y + half_balloon_height &&
//			    mouse_pos.x > transform.position.x - half_balloon_width &&
//			    mouse_pos.x < transform.position.x + half_balloon_width) {
//
//			
//				createPuffObject ("PuffDown", mouse_pos);
//				StartCoroutine (endPuff("PuffDown"));
//
//				Vector3 movement = new Vector3(0.0f, - speed, 0.0f);
//				transform.position += movement * speed * Time.deltaTime;
//
//			} else if (mouse_pos.y < transform.position.y - half_balloon_height && 
//			           mouse_pos.x > transform.position.x - half_balloon_width &&
//			           mouse_pos.x < transform.position.x + half_balloon_width) {
//					createPuffObject ("PuffUp", mouse_pos);
//					StartCoroutine (endPuff("PuffUp"));
//					
//				Vector3 movement = new Vector3(0.0f, speed, 0.0f);
//					transform.position += movement * speed * Time.deltaTime;
//			} else if (mouse_pos.x > transform.position.x + half_balloon_width && 
//			           mouse_pos.y > transform.position.y - half_balloon_height &&
//			           mouse_pos.y < transform.position.y + half_balloon_height) {
//				createPuffObject ("PuffLeft", mouse_pos);
//				StartCoroutine (endPuff("PuffLeft"));
//
//				Vector3 movement = new Vector3(- speed, 0.0f, 0.0f);
//				transform.position += movement * speed * Time.deltaTime;
//
//			} else if (mouse_pos.x < transform.position.x - half_balloon_width &&
//			           mouse_pos.y > transform.position.y - half_balloon_height &&
//			           mouse_pos.y < transform.position.y + half_balloon_height) {
//				createPuffObject ("PuffRight", mouse_pos);
//				StartCoroutine (endPuff("PuffRight"));
//
//				Vector3 movement = new Vector3(speed, 0.0f, 0.0f);
//				transform.position += movement * speed * Time.deltaTime;
//			}
//		} 
//
	}

//	void clearPuffs() {
//		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("puff")) {
//			Destroy (obj);
//		}
//	}
//
//	IEnumerator endPuff(string puff_name) {
//		// wait to play animation, then destroy the puff of air
//		yield return new WaitForSeconds(0.667f);
//		GameObject puff = GameObject.Find (puff_name);
//		if (puff != null) {
//			Destroy (puff);
//		}
//	}
	
	void OnCollisionEnter2D(Collision2D col){
		// Got a coin
		if (col.gameObject.name == "Fuel") {
			Destroy (col.gameObject);
			score += 5;
			score_object.text = "Score: " + score;
			GameObject potato = GameObject.Find("Potato");
			Bar bar_script = potato.GetComponent<Bar>();
			bar_script.barDisplay -= 0.1f;
		}
//		} else if (col.gameObject.name == "Bird") {
//			bird_hits++;
//			animator.Play ("balloon_hole");
//			if (bird_hits >=3) {
//				animator.Play ("balloon_pop_short");
//				StartCoroutine (endPop ());
//			}
//		} else if (col.gameObject.name == "Bolt") {
//			animator.Play ("balloon_pop_short");
//			StartCoroutine (endPop ());
//		}

	}

	public void noFuel() {
		animator.Play ("potato_smoking");
		StartCoroutine (endSmoke());
	}


//	public void createPuffObject(string prefab_name, Vector3 pos) {
//		GameObject newObject = GameObject.Instantiate(Resources.Load(prefab_name)) as GameObject;
//		newObject.gameObject.tag = "puff";
//		newObject.name = prefab_name;
//		newObject.gameObject.transform.position = pos;
//	}

	IEnumerator endSmoke() {
		// wait to play animation, then destroy Balloon 
		yield return new WaitForSeconds(1.333f);
		animator.Play ("potato_explode");
		StartCoroutine(endExplode());
	}

	IEnumerator endExplode() {
		// wait to play animation, then destroy Balloon 
		yield return new WaitForSeconds(0.250f);
		Destroy(this.gameObject);
		gameOver();
	}
//
//	public void endHole() {
//		while (transform.position.y > -5.0f) {
//			transform.position -= new Vector3 (0.0f, 0.01f, 0.0f);
//		}
//		gameOver();
//	}

	void gameOver() {
		if (gameover != null) {
			gameover.SetActive (true);
		}
		if (play_again != null) {
			play_again.SetActive (true);
		}
		final_score_object.text = "SCORE: " + score;
	}
	
}