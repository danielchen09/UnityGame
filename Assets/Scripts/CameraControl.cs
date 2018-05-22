using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour {

	public GameObject player;
	public GameObject healthBar;
	public GameObject energyBar;
	public GameObject score;
	public GameObject name;

	public GameObject enemy;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		player = Instantiate (Resources.Load<GameObject> ("Dad"), new Vector3 (0, 0, 0), Quaternion.identity);
		player.gameObject.name = "Player";
		offset = transform.position - player.transform.position;
		enemy = Instantiate (Resources.Load<GameObject> ("Murdue1"), new Vector3 (9, 2, 0), Quaternion.identity);
		enemy.gameObject.name = "Enemy";
		enemy = Instantiate (Resources.Load<GameObject> ("Murdue2"), new Vector3 (9, 2, 0), Quaternion.identity);
		enemy.gameObject.name = "Enemy";
		healthBar = GameObject.Find ("GUI/healthBar");
		energyBar = GameObject.Find ("GUI/energyBar");
		score = GameObject.Find ("GUI/score");
		name = GameObject.Find ("GUI/name");
	}
	
	// Update is called once per frame
	void Update () {
		//GUI

		name.GetComponent<Text> ().text = player.GetComponent<Player> ().getName ();
		transform.position = player.transform.position + offset;
		healthBar.transform.localScale = new Vector3 (2 * player.GetComponent<Player>().getHealth()/100f, 0.15f, 0);
		energyBar.transform.localScale = new Vector3 (2 * player.GetComponent<Player> ().getEnergy () / 100f, 0.05f, 0);
		score.GetComponent<Text> ().text = "score: " + player.GetComponent<Player> ().getScore ();
	}
}
