using UnityEngine;
using System.Collections;

public class MiniFridge : BoxProperties
{
    public void Start()
    {
        dimensions = new Vector3(1.0f, 2.0f, 1.0f);
        isHeavy = false;
        isFragile = false;
        isThisSideUp = true;
    }
}
