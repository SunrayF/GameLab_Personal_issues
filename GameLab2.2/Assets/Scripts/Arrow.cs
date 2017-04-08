using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public GameObject arrow;
	public GameObject bow;
	public float speed;
	public float speedAdd;
	private float timer;
	public float upgradePowerSpeed;
	private bool released;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		HoldArrow ();
		DrawingBow ();
	}

	void FixedUpdate(){

		if(Input.GetMouseButtonUp(0)){
			released = true;
			gameObject.AddComponent<Rigidbody>();
			arrow.transform.position = transform.position + Camera.main.transform.forward * 2;
			Rigidbody rb = arrow.GetComponent<Rigidbody>();
			rb.velocity = Camera.main.transform.forward * speed;
		}

	}

	void HoldArrow(){
		
		if(released == false){
			print ("holding");
		}
	}

	void DrawingBow(){

		if (Input.GetMouseButton (0)) {
			timer += Time.deltaTime;
			if (timer > upgradePowerSpeed) {
				speed += speedAdd;
				timer = 0;
			}
			print (speed);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		Destroy (gameObject.GetComponent<Rigidbody>());
		transform.parent = null;
		Destroy(gameObject.GetComponent<Arrow>());
	}
}
