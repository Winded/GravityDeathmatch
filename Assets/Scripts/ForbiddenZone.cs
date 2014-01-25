using System.Linq;
using UnityEngine;
using System.Collections;

public class ForbiddenZone : MonoBehaviour
{

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        var other = col.collider;
        if (other.gameObject.tag == "Player")
        {
            var norm = col.contacts.First().normal;
            other.transform.position += (Vector3)norm*2;
            print("YAY");
        }
    }

}
