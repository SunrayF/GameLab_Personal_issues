using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public bool sprinting;
	private float x;
	private float z;
	public float speed;
	public float runSpeed;

	void Start () {
		
	}

	void Update () {

		Move ();

	}

	void Move (){

		x = Input.GetAxis ("Horizontal") * Time.deltaTime * speed;
		z = Input.GetAxis ("Vertical") * Time.deltaTime * speed;

		transform.Translate(x, 0, z);
		print (x);

	}

	//void OnCollisionEnter (Collision col){
		
		//print ("hit");
	//}
}