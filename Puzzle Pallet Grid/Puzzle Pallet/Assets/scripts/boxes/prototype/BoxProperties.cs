using UnityEngine;
using System.Collections;

public class BoxProperties : MonoBehaviour {

    // Box dimensions
    protected Vector3 dimensions = new Vector3();

    // Speical Box Properties

        protected bool isHeavy { get; set; }
        protected bool isFragile { get; set; }
        protected bool isThisSideUp { get; set; }

    // Initializing
    public void Start()
    {
        dimensions = new Vector3(2.0f, 2.0f, 2.0f);

        isHeavy = false;
        isFragile = false;
        isThisSideUp = false;
    }

    // Returns Box Dimensions Only
    public Vector3 GetBoxDimensions ()
    {
        return dimensions;
    }

    // Returns Entire Box Object
    public BoxProperties GetBox()
    {
        return this;
    }
}


