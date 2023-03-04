using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
	PlayerMovement movement;	//Reference to the PlayerMovement script component
	Rigidbody2D rigidBody;		//Reference to the Rigidbody2D component
	PlayerInput input;			//Reference to the PlayerInput script component
	Animator anim;				//Reference to the Animator component

	int hangingParamID;			//ID of the isHanging parameter
	int groundParamID;			//ID of the isOnGround parameter
	int crouchParamID;			//ID of the isCrouching parameter
	int speedParamID;			//ID of the speed parameter
	int fallParamID;			//ID of the verticalVelocity parameter


	void Start()
	{
		//Get the integer hashes of the parameters. This is much more efficient
		//than passing strings into the animator
		hangingParamID = Animator.StringToHash("isHanging");
		groundParamID = Animator.StringToHash("isOnGround");
		crouchParamID = Animator.StringToHash("isCrouching");
		speedParamID = Animator.StringToHash("speed");
		fallParamID = Animator.StringToHash("verticalVelocity");

		//Grab a reference to this object's parent transform
		Transform parent = transform.parent;

		//Get references to the needed components
		movement	= GetComponent<PlayerMovement>();
		rigidBody	= GetComponent<Rigidbody2D>();
		input		= GetComponent<PlayerInput>();
		anim		= GetComponent<Animator>();
		
		//If any of the needed components don't exist...
		if(movement == null || rigidBody == null || input == null || anim == null)
		{
			//...log an error and then remove this component
			Debug.LogError("A needed component is missing from the player");
			Destroy(this);
		}
	}

	void Update()
	{
		//Update the Animator with the appropriate values
		anim.SetBool(hangingParamID, movement.isHanging);
		anim.SetBool(groundParamID, movement.isOnGround);
		anim.SetBool(crouchParamID, movement.isCrouching);
		anim.SetFloat(fallParamID, rigidBody.velocity.y);

		//Use the absolute value of speed so that we only pass in positive numbers
		anim.SetFloat(speedParamID, Mathf.Abs(input.horizontal));
	}


}
