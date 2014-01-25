using System.Linq;
using UnityEngine;

public class Controller2D : MonoBehaviour
{

    public float MoveAngle;

    public float JumpForce = 20f;
    public float Gravity = 20f;

    public float MoveSpeed = 10f;
    public float RotationSpeed = 90f;

    public Collider2D GroundDetector;

	public float horizontalInput;

	public Animator animator;
	public SpriteRenderer sprite;

    private bool _OnGround;
    private bool _Rotating;
	private int _PlayerID;

    private PlayerScript _Player;

    void Awake()
    {
        _Player = GetComponent<PlayerScript>();
        _PlayerID = transform.GetComponent<PlayerScript>().playerID;
    }

    void Start()
    {

		animator = sprite.GetComponent<Animator>();

	}
	
	void Update()
    {

		if (Input.GetButtonDown("Fire" + _PlayerID))
	    {
			_Player.ActionDown ();
		}

		if (Input.GetButtonUp ("Fire" + _PlayerID))
		{
			Vector2 input = new Vector2( Input.GetAxis("Horizontal" + _PlayerID), Input.GetAxis ("Vertical" + _PlayerID) );
			_Player.ActionUp(input);
		}

		if (Input.GetButton( "Fire" + _PlayerID))
		{
			transform.GetComponent<PlayerScript>().ActionHeld();
		}
    }

    void FixedUpdate()
    {

        UpdateVertical();

        UpdateHorizontal();

        UpdateAngle();

        _OnGround = false;

    }

    void UpdateHorizontal()
    {
        var horizontalInput = Input.GetAxis("Horizontal" + _PlayerID );
		animator.SetFloat("Speed", horizontalInput);

        var mdir = Vectors.RotateVector2(Vector2.right, MoveAngle)*horizontalInput*MoveSpeed;
        if (_OnGround && !_Rotating)
            rigidbody2D.AddForce(mdir);
    }

    void UpdateVertical()
    {

        var vdir = Vectors.RotateVector2(Vector2.up, MoveAngle);
        rigidbody2D.AddForce(vdir*Gravity*Time.deltaTime);

        if (Input.GetButtonDown("Jump" + _PlayerID) && _OnGround)
        {
            rigidbody2D.AddForce(vdir*JumpForce*Time.deltaTime);
        }

    }

    void UpdateAngle()
    {
        var euler = transform.rotation.eulerAngles;
        var diff = Angles.Difference(MoveAngle, euler.z);
        if (Mathf.Abs(diff) <= 2)
        {
            euler.z = euler.z + diff;
            _Rotating = false;
        }
        else
        {
            var rotamount = diff * Time.deltaTime * RotationSpeed;
            euler.z += rotamount;
            _Rotating = true;
        }
        transform.eulerAngles = euler;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.isTrigger)
            _OnGround = true;
    }

    public bool IsGrounded()
    {
        return _OnGround;
    }

}