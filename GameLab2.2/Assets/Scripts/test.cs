using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	public GameObject targetP;
	void Start () {
		gameObject.transform.parent = targetP.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
