using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retation : MonoBehaviour {
	public float speed = 1.0f;
	public Quaternion q;
    public Vector3 axis = new Vector3(1,1,1);
	// Use this for initialization
	void Start () {
		transform.position = new Vector3(1,0,0);
		q = Quaternion.AngleAxis (speed * Time.deltaTime , axis);
	}

	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		// transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);

		q = Quaternion.RotateTowards(q, Quaternion.AngleAxis (30 , new Vector3(1,1,0)),step/100);
		transform.localRotation *= q;
	}
}
