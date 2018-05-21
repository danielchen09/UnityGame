using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merida : MonoBehaviour, Player {

	private Animator animator;
	private Rigidbody2D rb;

	public float velocity;
	public int health;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		velocity = 0.5f;
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			animator.ResetTrigger ("idle");
			animator.SetTrigger ("walkLeft");
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			animator.ResetTrigger ("idle");
			animator.SetTrigger ("walkRight");
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			animator.ResetTrigger ("idle");
			animator.SetTrigger ("walkUp");
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			animator.ResetTrigger ("idle");
			animator.SetTrigger ("walkDown");
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
		}else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			animator.SetTrigger ("idle");
		}else if (Input.GetKeyUp (KeyCode.RightArrow)) {
			animator.SetTrigger ("idle");
		}else if (Input.GetKeyUp (KeyCode.DownArrow)) {
			animator.SetTrigger ("idle");
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			animator.SetTrigger ("shoot");
			rb.velocity = Vector2.zero;
		} 

		if (Input.GetKeyDown (KeyCode.R)) {
			GameObject arrow;
			Rigidbody2D arb;
			for (int i = 0; i <= 20; i++) {
				arrow = Instantiate (Resources.Load<GameObject> ("arrow"), transform.position + new Vector3 (Mathf.Cos(((360*(float)i/20)) * Mathf.PI/180), Mathf.Sin(((360*(float)i/20)) * Mathf.PI/180), 0), Quaternion.Euler (0, 0, (360*(float)i/20)-45));
				arb = arrow.GetComponent<Rigidbody2D> ();
				Debug.Log (arrow.transform.eulerAngles.z);
				arb.velocity = new Vector2 (2*Mathf.Cos((arrow.transform.eulerAngles.z+45) * Mathf.PI/180), 2*Mathf.Sin((arrow.transform.eulerAngles.z+45) * Mathf.PI/180));
			}
		}
	}

	public void attack(float x, float y){
		GameObject arrow;
		arrow = Instantiate (Resources.Load<GameObject> ("arrow"), transform.position + new Vector3(x, y, 0), Quaternion.Euler (0, 0, -45 + Mathf.Acos(x) * 180/Mathf.PI));
		arrow.GetComponent<Rigidbody2D> ().velocity = new Vector2 (20 * x, 20 * y);
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
}
