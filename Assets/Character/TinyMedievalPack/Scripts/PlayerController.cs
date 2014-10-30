using UnityEngine;
using System.Collections;

// Require these components when using this script
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour {


	public float animSpeed = 1.0f;

	private Animator anim;  // referance to the animator on the player
	private AnimatorStateInfo currentBaseState;  // a reference to the current state for the base layer
	private AnimatorStateInfo layer2CurrentState; // a reference to the current state of the 2nd layer
	private CapsuleCollider col;	// a reference to the capsule collider on the player

	//static int idleState = Animator.StringToHash("Base Layer.idle");
	static int runState = Animator.StringToHash("Base Layer.LocomotionFrontToBack");
	static int runState2 = Animator.StringToHash("Base Layer.LocomotionSideways");


	// Use this for initialization
	void Start () {

		// initialize reference variables
		anim = GetComponent<Animator> ();
		col = GetComponent<CapsuleCollider> ();

		if (anim.layerCount == 2)
						anim.SetLayerWeight (1, 1);

	
	}

	void FixedUpdate()
	{

		float h = Input.GetAxis ("Horizontal");						// setup h variable as our horizontal input axis
		float v = Input.GetAxis ("Vertical");						// setup v variable as our vertical input axis
		//anim.SetFloat ("Speed", v);									// set our animator's Speed parameter equal to the vertical input axis
		//anim.SetFloat ("Direction", h);								// set our animator's Direction parameter equal to the horizontal axis
		anim.speed = animSpeed;										// set the speed of our animator to the public variable animSpeed
		currentBaseState = anim.GetCurrentAnimatorStateInfo (0);	// set our currentState variable to the current state of the Base Layer (0) of the animator

		if (anim.layerCount == 2)
						layer2CurrentState = anim.GetCurrentAnimatorStateInfo (1);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Run()
	{
		anim.SetBool ("Run", true);
	}

	public void Strafe()
	{
		anim.SetBool ("Strafe", true);
	}

	public void ResetRun()
	{
		anim.SetBool ("Run", false);
	}

	public void ResetStrafe()
	{
		anim.SetBool ("Strafe", false);
	}

}
