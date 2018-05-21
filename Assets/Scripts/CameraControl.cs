using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public GameObject player;
	public GameObject healthBar;

	public GameObject enemy;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		player = Instantiate (Resources.Load<GameObject> ("Merida"), new Vector3 (0, 0, 0), Quaternion.identity);
		player.gameObject.name = "Player";
		offset = transform.position - player.transform.position;
		enemy = Instantiate (Resources.Load<GameObject> ("Murdue2"), new Vector3 (9, 2, 0), Quaternion.identity);
		enemy.gameObject.name = "Enemy";
		healthBar = GameObject.Find ("GUI/healthBar");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + offset;
		healthBar.transform.localScale = new Vector3 (2 * player.GetComponent<Player>().getHealth()/100f, 0.15f, 0);
	}
}
