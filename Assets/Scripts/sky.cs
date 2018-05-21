using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sky : MonoBehaviour {
	
	public float speed = 1;
	private float offset;
	private float direction = 1;

	RectTransform rt;

	// Use this for initialization
	void Start () {
		rt = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		offset += (int)(Time.time * speed * 0.1);
		rt.anchoredPosition = new Vector3 (263, -170 - offset, 0);
		if (rt.anchoredPosition.y < -523) {
			speed *= -1;
			rt.anchoredPosition = new Vector3 (263, -515, 0);
		} else if (rt.anchoredPosition.y > 0) {
			speed *= -1;
			rt.anchoredPosition = new Vector3 (263, -15, 0);
		}
	}
}
