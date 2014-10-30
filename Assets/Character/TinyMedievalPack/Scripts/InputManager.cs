using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	private Vector3 forward;
	private Vector3 back;
	private Vector3 left;
	private Vector3 right;
	private float moveSpeed = 3.0f;

	private PlayerController controller;
	
	// Use this for initialization
	void Start () {

		forward = transform.forward;
		back = -transform.forward;
		left = -transform.right;
		right = transform.right;

		controller = GetComponent<PlayerController> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (KeyCode.W)) 
		{
			controller.ResetRun();
		}

		if (Input.GetKey (KeyCode.W)) 
		{
			transform.forward = forward;
			transform.position += moveSpeed * Time.deltaTime * transform.forward;
			controller.Run();
		}

		if (Input.GetKeyUp (KeyCode.S)) 
		{
			controller.ResetRun();
		}

		if (Input.GetKey (KeyCode.S)) 
		{
			transform.forward = back;
			transform.position += moveSpeed * Time.deltaTime * transform.forward;
			controller.Run();
		}

		if (Input.GetKeyUp (KeyCode.A)) 
		{
			controller.ResetStrafe();
		}
		
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.forward = left;
			transform.position += moveSpeed * Time.deltaTime * transform.forward;
			controller.Strafe();
		}

		if (Input.GetKeyUp (KeyCode.D)) 
		{
			controller.ResetStrafe();
		}

		if (Input.GetKey (KeyCode.D)) 
		{
			transform.forward = right;
			transform.position += moveSpeed * Time.deltaTime * transform.forward;
			controller.Strafe();
		}
		
		
		
	}
}