using UnityEngine;
using System.Collections;

public static class Vectors
{

    public static Vector2 RotateVector2(Vector2 vector, float angle)
    {
        var theta = Mathf.Deg2Rad*angle;
        var cs = Mathf.Cos(theta);
        var sn = Mathf.Sin(theta);
        var x = vector.x * cs - vector.y * sn; 
        var y = vector.x * sn + vector.y * cs;
        return new Vector2(x, y);
    }

}