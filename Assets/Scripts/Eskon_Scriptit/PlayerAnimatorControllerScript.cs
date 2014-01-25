using UnityEngine;
using System.Collections;

public class PlayerAnimatorControllerScript : MonoBehaviour
{
	
	//public float maxSpeed = 10f;
	bool facingRight = false;
	//public Vector2 currentVelocity;
	public float move;
	public bool jumping = false;
	public bool gotHit = false;
	public bool Killed = false;
	
	
	private Animator _Animator;
	
	// Use this for initialization
	private void Start()
	{
		
	}
	
	private void Awake()
	{
		_Animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		
		//move = Input.GetAxis("Horizontal");
		_Animator.SetFloat("Speed", Mathf.Abs (move));

		
		if (move > 0 && !facingRight)
			Flip ();
		if (move < 0 && facingRight)
			Flip ();

		if (jumping)
		{
			_Animator.SetTrigger("Jumping");
			jumping = !jumping;
		}

		if (gotHit)
		{
			_Animator.SetTrigger("Gothit");
			gotHit = !gotHit;
		}

		if (Killed)
		{
			_Animator.SetTrigger("Killed");
			Killed = !Killed;
		}

	}
	
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
