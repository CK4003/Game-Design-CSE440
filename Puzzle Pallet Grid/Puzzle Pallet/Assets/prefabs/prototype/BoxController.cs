using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour {

    // Array to keep boxes
    public BoxProperties[] BoxSelector;

    public Transform boxRotationTransform
	{
		get{
			return transform.GetChild(0);
		}
	}

	public Color boxColor
	{
		set
		{
			this.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = value;
		}
	}

	public Rigidbody boxRigidBody;

	public int maxAxis;

	public int minAxis;

	// Use this for initialization
	void Start () {
        //TODO remove this demo code
        transform.localScale = BoxSelector[Random.Range(0, 15)].GetBoxDimensions();
        //this.boxColor = Color.clear;
		this.boxRigidBody.isKinematic = true;
		this.name = string.Format ("BOX({0}x{1}x{2})",transform.localScale.x,transform.localScale.y,transform.localScale.z);
	}
    //Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f)
	private int randomUnitSize()
	{
		return (int)Mathf.Floor (Random.Range (minAxis, maxAxis+1));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
