﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	private GameObject owner;

	private float initial;

	// Use this for initialization
	void Start () {
		initial = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - initial >= 3)
			Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (!col.name.Equals (gameObject.name)) {
			Debug.Log (col.name);
			Destroy (gameObject);
		}
		if (col.name.IndexOf ("Enemy") != -1 && owner.gameObject.name.IndexOf ("Enemy") != -1) {
			col.GetComponent<Enemy> ().setHealth (col.GetComponent<Enemy> ().getHealth () - owner.GetComponent<Enemy> ().getDamage ());
			col.GetComponent<Enemy> ().getHealthBar ().transform.localScale = new Vector3 (0.06f * col.GetComponent<Enemy> ().getHealth () / 100, 0, 0.007f);
			Destroy (gameObject);
		}else if(col.name.IndexOf ("Enemy") != -1 && owner.gameObject.name.IndexOf ("Player") != -1){ 
			col.GetComponent<Enemy> ().setHealth (col.GetComponent<Enemy> ().getHealth () - owner.GetComponent<Player> ().getDamage ());
			col.GetComponent<Enemy> ().getHealthBar ().transform.localScale = new Vector3 (0.06f * col.GetComponent<Enemy> ().getHealth () / 100, 0, 0.007f);
			Destroy (gameObject);
		}else if (col.name.IndexOf ("Player") != -1) {
			col.GetComponent<Player> ().setHealth (col.GetComponent<Player> ().getHealth () - owner.GetComponent<Enemy> ().getDamage ());	
		} 
	}

	public GameObject getOwner(){
		return owner;
	}

	public void setOwner(GameObject owner){
		this.owner = owner;
	}
}
