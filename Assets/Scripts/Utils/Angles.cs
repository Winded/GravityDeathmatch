using UnityEngine;

public static class Angles
{
    public static float Difference(float a, float b)
    {
        var r = a - b;
        while (r < -180) r += 360;
        while (r > 180) r -= 360;
        return r;
    }
}