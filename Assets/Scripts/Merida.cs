﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merida : MonoBehaviour, Player {

	private Animator animator;
	private Rigidbody2D rb;

	private string name;
	private float velocity;
	private int health;
	private int energy;
	private bool updateWalk = true;
	private int score;
	private int damage;

	// Use this for initialization
	void Start () {
		name = "Merida";
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		velocity = 1.0f;
		health = 100;
		energy = 0;
		score = 0;
		damage = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if (health > 0) {
			if (Input.GetKey (KeyCode.LeftArrow) && updateWalk) {
				animator.ResetTrigger ("idle");
				animator.SetTrigger ("walkLeft");
				updateWalk = false;
			} else if (Input.GetKey (KeyCode.RightArrow) && updateWalk) {
				animator.ResetTrigger ("idle");
				animator.SetTrigger ("walkRight");
				updateWalk = false;
			} else if (Input.GetKey (KeyCode.UpArrow) && updateWalk) {
				animator.ResetTrigger ("idle");
				animator.SetTrigger ("walkUp");
				updateWalk = false;
			} else if (Input.GetKey (KeyCode.DownArrow) && updateWalk) {
				animator.ResetTrigger ("idle");
				animator.SetTrigger ("walkDown");
				updateWalk = false;
			}

			if (Input.GetKey (KeyCode.LeftArrow)) {
				rb.velocity = new Vector2 (Input.GetAxis ("Horizontal"), 0) * velocity * 2;
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				rb.velocity = new Vector2 (Input.GetAxis ("Horizontal"), 0) * velocity * 2;
			} else if (Input.GetKey (KeyCode.UpArrow)) {
				rb.velocity = new Vector2 (0, Input.GetAxis ("Vertical")) * velocity * 2;
			} else if (Input.GetKey (KeyCode.DownArrow)) {
				rb.velocity = new Vector2 (0, Input.GetAxis ("Vertical")) * velocity * 2;
			} else {
				rb.velocity = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
			}

			if (Input.GetKeyUp (KeyCode.UpArrow)) {
				animator.SetTrigger ("idle");
				updateWalk = true;
			} else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
				animator.SetTrigger ("idle");
				updateWalk = true;
			} else if (Input.GetKeyUp (KeyCode.RightArrow)) {
				animator.SetTrigger ("idle");
				updateWalk = true;
			} else if (Input.GetKeyUp (KeyCode.DownArrow)) {
				animator.SetTrigger ("idle");
				updateWalk = true;
			}

			if (Input.GetKeyDown (KeyCode.Z)) {
				animator.SetTrigger ("shoot");
				rb.velocity = Vector2.zero;
			} 

			if (Input.GetKeyDown (KeyCode.R) && energy >= 50) {
				GameObject arrow;
				for (int i = 0; i <= 20; i++) {
					arrow = Instantiate (Resources.Load<GameObject> ("arrow"), transform.position + new Vector3 (Mathf.Cos (((360 * (float)i / 20)) * Mathf.PI / 180), Mathf.Sin (((360 * (float)i / 20)) * Mathf.PI / 180), 0), Quaternion.Euler (0, 0, (360 * (float)i / 20) - 45));
					arrow.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2 * Mathf.Cos ((arrow.transform.eulerAngles.z + 45) * Mathf.PI / 180), 2 * Mathf.Sin ((arrow.transform.eulerAngles.z + 45) * Mathf.PI / 180));;
					arrow.GetComponent<Arrow> ().setOwner (gameObject);
				}
				energy -= 50;
			}
		} else {
			velocity = 0;
			foreach (GameObject g in Object.FindObjectsOfType<GameObject>()) {
				if (g.name.IndexOf ("Enemy") != -1)
					GameObject.Destroy (g);
			}
		}
	}

	public void attack(float x, float y){
		GameObject arrow;
		arrow = Instantiate (Resources.Load<GameObject> ("arrow"), transform.position + new Vector3(x, y, 0), Quaternion.Euler (0, 0, -45 + Mathf.Acos(x) * 180/Mathf.PI));
		arrow.GetComponent<Rigidbody2D> ().velocity = new Vector2 (20 * x, 20 * y);
		arrow.GetComponent<Arrow> ().setOwner (gameObject);
	}

	public string getName(){
		return name;
	}
	public float getVelocity(){
		return velocity;
	}
	public void setVelocity(float velocity){
		this.velocity = velocity;
	}
	public int getHealth(){
		return health;
	}
	public void setHealth(int health){
		this.health = Mathf.Max(health, 0);
	}
	public int getEnergy(){
		return energy;
	}
	public void setEnergy(int energy){
		this.energy = energy;
	}
	public void incrementEnergy(int energy){
		this.energy += (this.energy + energy > 100) ? 0 : energy;
	}
	public int getDamage(){
		return damage;
	}
	public void setDamage(int damage){
		this.damage = damage;
	}
	public int getScore(){
		return score;
	}
	public void setScore(int score){
		this.score = score;
	}
}
