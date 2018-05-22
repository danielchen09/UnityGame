using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeHitBox : MonoBehaviour {

	private GameObject owner;

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
		if (!col.name.Equals (owner.gameObject.name)) {
			if (col.name.IndexOf ("Player") != -1) {
				col.GetComponent<Player> ().setHealth (col.GetComponent<Player> ().getHealth () - owner.GetComponent<Enemy> ().getDamage ());
			} else if (col.name.IndexOf ("Enemy") != -1 && owner.gameObject.name.IndexOf("Ememy") != -1) {
				col.GetComponent<Enemy> ().setHealth (col.GetComponent<Enemy> ().getHealth () - owner.GetComponent<Enemy> ().getDamage ());
				col.GetComponent<Enemy> ().getHealthBar ().transform.localScale = new Vector3 (0.06f * col.GetComponent<Enemy> ().getHealth () / 100, 0, 0.007f);
				Destroy (gameObject);
			} else if (col.name.IndexOf ("Enemy") != -1 && owner.gameObject.name.IndexOf("Player") != -1) {
				col.GetComponent<Enemy> ().setHealth (col.GetComponent<Enemy> ().getHealth () - owner.GetComponent<Player> ().getDamage ());
				col.GetComponent<Enemy> ().getHealthBar ().transform.localScale = new Vector3 (0.06f * col.GetComponent<Enemy> ().getHealth () / 100, 0, 0.007f);
				Destroy (gameObject);
			}
		}
	}

	public GameObject getOwner(){
		return owner;
	}

	public void setOwner(GameObject owner){
		this.owner = owner;
	}
}
