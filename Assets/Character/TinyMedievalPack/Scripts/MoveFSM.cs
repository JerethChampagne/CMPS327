using UnityEngine;
using System.Collections;

public enum MoveStates
{
	idle,
	walk,
	run,
	jump
}

public class MoveFSM : MonoBehaviour 
{
	public AnimationClip idle;
	public AnimationClip walk;
	public AnimationClip run;
	public AnimationClip jump;
	
	
	
	public MoveStates CurrentState;
	
	public MoveStates PreviousState;
	
	public float MoveSpeed;
	
	public float TurnSpeed;
	
	string currentAnimation;
	
	public Rigidbody rigidbody;
	
	Animation animation;
	
	void Awake()
	{
		rigidbody = gameObject.rigidbody;
		
		animation = gameObject.animation;
		
		#region setting up animator
		animation.playAutomatically = true;
		
		animation.AddClip(idle, "Idle");
		animation.AddClip(walk, "Walk");
		animation.AddClip(run, "Run");
		animation.AddClip(jump, "Jump");
		
		animation["Walk"].layer = 1;
		animation["Idle"].layer = 1;
		animation["Run"].layer = 1;
		animation["Jump"].layer = 1;
		
		animation["Walk"].wrapMode = WrapMode.Loop;
		animation["Idle"].wrapMode = WrapMode.Loop;
		animation["Run"].wrapMode = WrapMode.Loop;
		animation["Jump"].wrapMode = WrapMode.Once;
		
		currentAnimation = "Idle";
		#endregion
	}
	
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		switch (CurrentState)
		{
		case MoveStates.idle:
			
			animation.Play("Idle", PlayMode.StopAll);
			
			
			
			break;
			
		case MoveStates.walk:
			
			animation.CrossFade("Walk", 0.1f);
			rigidbody.velocity = transform.forward * MoveSpeed * Time.deltaTime;
			break;
			
			
		case MoveStates.run:
			rigidbody.velocity = transform.forward * MoveSpeed * Time.deltaTime * 1.5f;
			animation.CrossFade("Run", 0.1f);
			
			break;
			
		case MoveStates.jump:
			
			animation.CrossFade("Jump", 0.1f);
			
			break;
			
		default:
			
			break;
			
		}
	}
	
	
	public void Turn(int direction)
	{
		transform.Rotate(Vector3.up, direction * TurnSpeed * Time.deltaTime);
	}
}

