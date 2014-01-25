using System.Linq;
using UnityEngine;

public class Controller2D : MonoBehaviour
{

    public float MoveAngle;

    public float JumpForce = 20f;
    public float Gravity = 20f;

    public float MoveSpeed = 10f;

    public Collider2D GroundDetector;

    //private float _VSpeed;
    //private float _Speed;
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
        }
		var euler = transform.rotation.eulerAngles;
		euler.z = MoveAngle;
		transform.rotation = Quaternion.Euler(euler);

        UpdateVertical();

        UpdateHorizontal();

    }

    void FixedUpdate()
    {
        _OnGround = false;
    }

    void UpdateHorizontal()
    {
        var x = Input.GetAxis("Horizontal");
        var mdir = Vectors.RotateVector2(Vector2.right, MoveAngle)*x*MoveSpeed;
        if (_OnGround)
            rigidbody2D.AddForce(mdir);
    }

    void UpdateVertical()
    {

        var vdir = Vectors.RotateVector2(Vector2.up, MoveAngle);
        //rigidbody2D.AddForce(vdir*Gravity*Time.deltaTime);

        if (Input.GetButtonDown("Jump") && _OnGround)
        {
            rigidbody2D.AddForce(vdir*JumpForce*Time.deltaTime);
        }

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
        //_VSpeed = JumpForce;
    }

}