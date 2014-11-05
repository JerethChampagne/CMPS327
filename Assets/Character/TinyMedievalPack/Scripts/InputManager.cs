using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	
	private float moveSpeed = 3.0f;
	public float Turnspeed;
	
	private PlayerController controller;
	
	// Use this for initialization
	void Start () {
		
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
			
			//transform.forward = Camera.main.transform.forward;
			transform.position += moveSpeed * Time.deltaTime * transform.forward;
			controller.Run();
			
		}
		
		if (Input.GetKeyUp (KeyCode.S)) 
		{
			controller.ResetRun();
		}
		
		if (Input.GetKey (KeyCode.S)) 
		{
			
			transform.position -= moveSpeed * Time.deltaTime * transform.forward;
			controller.Run();
			
		}
		
		if (Input.GetKeyUp (KeyCode.A)) 
		{
			controller.ResetStrafe();
		}
		
		if (Input.GetKey (KeyCode.A)) 
		{
			
			transform.Rotate(Vector3.up, -1f * Turnspeed * Time.deltaTime);
			//transform.position -= moveSpeed * Time.deltaTime * transform.right;
			//controller.Strafe();
			
		}
		
		if (Input.GetKeyUp (KeyCode.D)) 
		{
			controller.ResetStrafe();
		}
		
		if (Input.GetKey (KeyCode.D)) 
		{
			
			transform.Rotate(Vector3.up, 1f * Turnspeed * Time.deltaTime);
			//transform.position += moveSpeed * Time.deltaTime * transform.right;
			//controller.Strafe();
			
		}
		
		
		
	}
	
	
}