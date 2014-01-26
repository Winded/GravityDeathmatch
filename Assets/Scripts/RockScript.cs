using UnityEngine;
using System.Collections;

public class RockScript : MonoBehaviour
{

    public float VelocityMagnitude = 1f;

    // Use this for initialization
    private void Start()
    {
        var rndAng = Random.Range(-180f, 180f);
        var euler = transform.eulerAngles;
        euler.z = rndAng;
        transform.eulerAngles = euler;
        var vDir = transform.right;
        rigidbody2D.velocity = vDir*VelocityMagnitude;
    }

    // Update is called once per frame
    private void Update()
    {

    }
}
