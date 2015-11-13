using UnityEngine;
using System.Collections;

public class GlassContainer : BoxProperties
{ 
    public void Start()
    {
        dimensions = new Vector3(1.0f, 1.0f, 1.0f);
        isHeavy = false;
        isFragile = true;
        isThisSideUp = Random.value > 0.5f;
    }
}

