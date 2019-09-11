using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var obj = GameObject.Find("Table");
		Debug.Log(obj);

		GameObject subele = GameObject.CreatePrimitive(PrimitiveType.Cube);
		subele.name = "sub";
		subele.transform.position = new Vector3(0,3,0);
		subele.transform.parent = obj.transform;

		var trans = obj.transform;
		foreach(Transform sub in trans)
		{
			Debug.Log(sub.name);
			Destroy(sub.gameObject);
		}


	}

	// Update is called once per frame
	void Update () {

	}
}
