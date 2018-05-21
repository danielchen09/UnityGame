using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murdue2 : MonoBehaviour, Enemy {

	private Animator animator;
	private Rigidbody2D rb;

	private float velocity;
	private int health;
	private string[] DIRECTIONS = {"Up", "Down", "Left", "Right", "Stop"};
	private string direction;
	private float init;
	private float updateTime;
	public bool isAttacking;

	private GameObject player;
	private GameObject healthBar;
	private GameObject healthBar_bg;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		player = GameObject.Find ("Player");
		velocity = 1;
		health = 100;
		init = Time.time;
		updateTime = Time.time;
		direction = DIRECTIONS [Random.Range (0, 3)];
		healthBar = Instantiate (Resources.Load<GameObject> ("healthBarEnemy"), transform.position + new Vector3(0, 0.6f, -1), Quaternion.Euler(270, 0, 0));
	}

	// Update is called once per frame
	void Update () {
		if (health > 0) {
			float dist = Mathf.Sqrt (Mathf.Pow (transform.position.x - player.transform.position.x, 2) + Mathf.Pow (transform.position.y - player.transform.position.y, 2));
			float cos = (player.transform.position.x - transform.position.x) / dist;
			float sin = (player.transform.position.y - transform.position.y) / dist;
			if (transform.position.y - player.transform.position.y > 0) {
				transform.position = new Vector3 (transform.position.x, transform.position.y, 1);
			} else {
				transform.position = new Vector3 (transform.position.x, transform.position.y, -1);
			}
			if (dist <= 5.0f || isAttacking) {
				rb.velocity = Vector2.zero;
				if (Time.time - updateTime >= 1) {
					facePlayer (cos, sin);
					updateTime = Time.time;
				}
				animator.ResetTrigger ("idle");
				animator.SetTrigger ("shoot");
			} else if (dist <= 8) {
				rb.velocity = new Vector2 (velocity * cos, velocity * sin);
				facePlayer (cos, sin);
			} else {
				changeDirection ();
			}
			healthBar.transform.position = transform.position + new Vector3 (0, 0.6f, -2);
		} else {
			rb.velocity = Vector2.zero;
			animator.SetTrigger ("death");
		}
	}

	void facePlayer(float cos, float sin){
		if (Mathf.Abs (sin) > Mathf.Abs (cos)) {
			if (sin < 0) {
				animator.ResetTrigger ("idle");
				animator.SetTrigger ("walkDown");
			} else {
				animator.ResetTrigger ("idle");
				animator.SetTrigger ("walkUp");
			}
		} else {
			if (cos < 0) {
				animator.ResetTrigger ("idle");
				animator.SetTrigger ("walkLeft");
			} else {
				animator.ResetTrigger ("idle");
				animator.SetTrigger ("walkRight");
			}
		}
	}

	void changeDirection(){
		if (!direction.Equals ("stop")) {
			animator.ResetTrigger ("idle");
			if (Time.time - init >= 2) {
				animator.SetTrigger ("walk" + direction);
				if (direction.Equals ("Up")) {
					rb.velocity = new Vector2 (0, velocity);
				} else if (direction.Equals ("Down")) {
					rb.velocity = new Vector2 (0, -velocity);
				} else if (direction.Equals ("Left")) {
					rb.velocity = new Vector2 (-velocity, 0);
				} else if (direction.Equals ("Right")) {
					rb.velocity = new Vector2 (velocity, 0);
				}
				if (Time.time - init > 4) {
					Debug.Log (Time.time - init);
					direction = DIRECTIONS [Random.Range (0, 3)];
					animator.SetTrigger ("walk" + direction);
					init = Time.time;
					animator.SetTrigger ("idle");
					rb.velocity = Vector2.zero;
				}
			}
		} else {
			rb.velocity = Vector2.zero;
			animator.SetTrigger ("idle");
		}
	}

	public void attack(){
		Debug.Log ("DSAFASD");
		float dist = Mathf.Sqrt (Mathf.Pow (transform.position.x - player.transform.position.x, 2) + Mathf.Pow (transform.position.y - player.transform.position.y, 2));
		float cos = (player.transform.position.x - transform.position.x) / dist;
		float sin = (player.transform.position.y - transform.position.y) / dist;
		GameObject arrow;
		arrow = Instantiate (Resources.Load<GameObject> ("arrow"), transform.position + new Vector3 (cos, sin, 0), Quaternion.Euler (0, 0, -45 + ((cos>=0)?Mathf.Atan(sin/cos):Mathf.Atan(sin/cos)+Mathf.PI) * 180/Mathf.PI));
		arrow.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2 * cos, 2 * sin);
	}

	public void attacking (bool b){
		isAttacking = b;
	}

	public int getHealth(){
		return health;
	}
	public void setHealth(int health){
		this.health = Mathf.Max(health, 0);
	}
	public GameObject getHealthBar(){
		return healthBar;
	}
}
