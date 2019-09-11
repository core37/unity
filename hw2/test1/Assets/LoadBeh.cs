using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBeh : MonoBehaviour {

	public Transform res;

	// Use this for initialization
	void Start () {
		// Load Resources
		Object table = Resources.Load("Table");
		GameObject newobj = Instantiate(table) as GameObject;
		newobj.transform.position = new Vector3 (0, Random.Range (-5, 5), 0);
		newobj.transform.parent = this.transform;
	}
}