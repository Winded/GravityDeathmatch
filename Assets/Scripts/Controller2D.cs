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

    private bool _OnGround;
    private bool _Rotating;

    void Awake()
    {
           
    }

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            MoveAngle += 90f;
            MoveAngle %= 360f;
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
        var x = Input.GetAxis("Horizontal");
        var mdir = Vectors.RotateVector2(Vector2.right, MoveAngle)*x*MoveSpeed;
        if (_OnGround && !_Rotating)
            rigidbody2D.AddForce(mdir);
    }

    void UpdateVertical()
    {

        var vdir = Vectors.RotateVector2(Vector2.up, MoveAngle);
        rigidbody2D.AddForce(vdir*Gravity*Time.deltaTime);

        if (Input.GetButtonDown("Jump") && _OnGround)
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