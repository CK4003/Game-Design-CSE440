using UnityEngine;
using System.Collections;

public class CardboardBox : BoxProperties
{
    public void Start()
    {
        dimensions = new Vector3(1.0f, 1.0f, 1.0f);
        isHeavy = Random.value > 0.5f;
        isFragile = Random.value > 0.5f;
        isThisSideUp = Random.value > 0.5f;
    }
}
