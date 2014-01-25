using UnityEngine;
using System.Collections;

public class PlayerAnimatorControllerScript : MonoBehaviour
{

	public float maxSpeed = 10f;
	bool facingRight = true;
	public Vector2 currentVelocity

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
	    float move = Input.GetAxis("Horizontal");
	    _Animator.SetFloat("Speed", move);
		if (move > 0 && facingRight)
			Flip ();
		if (move < 0 && !facingRight)
			Flip ();
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
