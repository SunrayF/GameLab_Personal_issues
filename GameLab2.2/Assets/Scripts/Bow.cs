using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

	public GameObject arrow;
	public GameObject arrowP;
	public float reloadTime;
	private float timer;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Reload ();
	}

	void Reload(){
		print (transform.childCount);
		if (transform.childCount > 1) {
			print ("loaded");
			timer = 0;
		}
		else{
			timer += Time.deltaTime;
			if (timer > reloadTime) {
				GameObject newArrow = (GameObject)Instantiate (arrow, new Vector3 (arrowP.transform.position.x, arrowP.transform.position.y, arrowP.transform.position.z), Quaternion.identity);
				newArrow.transform.parent = gameObject.transform;
				timer = 0;
			}
		}
	}
}
