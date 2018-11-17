using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class VectorExtensions
{
    public static Vector3 Scale(this Vector3 vector, float factor)
    {
        Vector3 result = new Vector3(vector.x * factor, vector.y *factor, vector.z * factor);
        return result;
    }
}

