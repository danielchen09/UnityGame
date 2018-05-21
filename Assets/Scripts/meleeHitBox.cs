using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeHitBox : MonoBehaviour {

	private float initial;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D col){

		Debug.Log ("HIT");
		if (!col.name.Equals (gameObject.name)) {
			Destroy (gameObject);
		}
		if(col.name.Equals("Player")){
			col.GetComponent<Player>().setHealth(col.GetComponent<Player>().getHealth() - 10);
		}
	}
}
