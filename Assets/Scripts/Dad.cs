using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dad: MonoBehaviour, Player {

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
		name = "Dad";
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		velocity = 1.0f;
		health = 100;
		energy = 0;
		score = 0;
		damage = 30;
	}

	// Update is called once per frame
	void Update () {
		if (health > 0) {
			//movement animation
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

			//movement
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

			//movement stop animation
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

			//light attack
			if (Input.GetKeyDown (KeyCode.Z)) {
				animator.SetTrigger ("melee");
				rb.velocity = Vector2.zero;
			} 

			//ultimate
			if (Input.GetKeyDown (KeyCode.R)) {
				incrementHealth (energy);
				energy = 0;
			}
		} else {
			//death
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
	public void incrementHealth(int health){
		this.health += (this.health + health > 100) ? 0 : health;
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
