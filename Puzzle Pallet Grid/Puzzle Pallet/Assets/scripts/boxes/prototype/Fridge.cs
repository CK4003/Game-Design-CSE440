using UnityEngine;
using System.Collections;

public class Fridge : BoxProperties
{
    public void Start()
    {
        dimensions = new Vector3(2.0f, 3.0f, 2.0f);
        isHeavy = true;
        isFragile = false;
        isThisSideUp = true;
    }
}
