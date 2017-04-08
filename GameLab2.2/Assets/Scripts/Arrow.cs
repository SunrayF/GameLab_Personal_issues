using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public GameObject arrow;
	public float maxDrawTime;
	private float drawTimer;
	public GameObject bow;
	public float speed;
	public float speedAdd;
	public Camera cam;
	public float adsFOV;
	private float timer;
	private float zoomTimer;
	public float zoomTime;
	public float upgradePowerSpeed;
	private bool released = true;
	private float cameraFov;

	void Start () {
		cam = Camera.main;
		cameraFov = Camera.main.fieldOfView;
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
			cam.fieldOfView = cameraFov;
		}

	}

	void HoldArrow(){
		
		if(released == false){
			print ("holding");
		}
	}

	void DrawingBow(){

		if (Input.GetMouseButton (0)) {
			drawTimer += Time.deltaTime;
			if(drawTimer < maxDrawTime){
				timer += Time.deltaTime;
				zoomTimer += Time.deltaTime;
				if (zoomTimer > zoomTime) {
					cam.fieldOfView -= adsFOV;
					zoomTimer = 0;
				}
				if (timer > upgradePowerSpeed) {
					speed += speedAdd;
					timer = 0;
				}
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		Destroy (gameObject.GetComponent<Rigidbody>());
		transform.parent = null;
		Destroy(gameObject.GetComponent<Arrow>());
	}
}
