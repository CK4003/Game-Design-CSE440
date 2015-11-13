using UnityEngine;
using System.Collections;

public class LargeFlatScreenTV : BoxProperties
{
    public void Start()
    {
        dimensions = new Vector3(3.0f, 2.0f, 1.0f);
        isHeavy = false;
        isFragile = false;
        isThisSideUp = true;
    }
}
