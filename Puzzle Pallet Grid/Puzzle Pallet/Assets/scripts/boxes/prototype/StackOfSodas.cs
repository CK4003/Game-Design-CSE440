using UnityEngine;
using System.Collections;

public class StackOfSodas : BoxProperties
{
    public void Start()
    {
        dimensions = new Vector3(1.0f, 1.0f, 1.0f);
        isHeavy = false;
        isFragile = false;
        isThisSideUp = false;
    }
}
