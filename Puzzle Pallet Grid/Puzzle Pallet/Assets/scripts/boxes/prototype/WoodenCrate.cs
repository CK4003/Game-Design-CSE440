using UnityEngine;
using System.Collections;

public class WoodenCrate : BoxProperties
{
    public void Start()
    {
        dimensions = new Vector3(1.0f, 1.0f, 1.0f);
        isHeavy = true;
        isFragile = false;
        isThisSideUp = Random.value > 0.5f;
    }
}
