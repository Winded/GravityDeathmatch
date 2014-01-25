using System.Linq;
using UnityEngine;

public class Controller2D : MonoBehaviour
{

    public float MoveAngle;

    public float JumpForce = 20f;
    public float Gravity = 20f;

    public float MoveSpeed = 10f;

    public Collider2D GroundDetector;

    private float _VSpeed;
    private float _Speed;
    private bool _OnGround;

    void Awake()
    {
           
    }

    private void Start()
    {

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            MoveAngle += 90f;
            MoveAngle %= 360f;
            var euler = transform.rotation.eulerAngles;
            euler.z = MoveAngle;
            transform.rotation = Quaternion.Euler(euler);
        }

        UpdateVSpeed();

        UpdateSpeed();

    }

    void FixedUpdate()
    {
        var vdir = Vectors.RotateVector2(Vector2.up, MoveAngle)*_VSpeed;
        var mdir = Vectors.RotateVector2(Vector2.right, MoveAngle)*_Speed;

        var vel = vdir + mdir;
        print(vel);
        rigidbody2D.AddForce(vel);

        _OnGround = false;
    }

    void UpdateSpeed()
    {
        var x = Input.GetAxis("Horizontal");
        if (_OnGround)
            _Speed = x*MoveSpeed;
    }

    void UpdateVSpeed()
    {

        _VSpeed -= Gravity*Time.deltaTime;

        if (Input.GetButtonDown("Jump") && _OnGround)
        {
            Jump();
        }

        // Remove gravitational pull when on ground (stops slippering)
        if (_OnGround && _VSpeed < 0)
            _VSpeed = 0;

    }

    void OnTriggerStay2D(Collider2D other)
    {

        _OnGround = true;

    }

    public bool IsGrounded()
    {
        return _OnGround;
    }

    public void Jump()
    {
        _VSpeed = JumpForce;
    }

}