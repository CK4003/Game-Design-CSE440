using UnityEngine;
using System.Collections;

public class GridSystemMovement : MonoBehaviour {

	public Transform gridOrigin;

	public Vector2 gridMinimum;

	public Vector2 gridMaximum;

	public Vector2 gridStride;

	private Transform holdingBox;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HoldBox(Transform holdingBox)
	{
		this.holdingBox = holdingBox;
		this.holdingBox.position = this.transform.position;
	}

	public void ReleaseBox()
	{
		this.holdingBox = null;
	}

	public Vector3 MoveBlock(int x,int z)
	{
		if (this.holdingBox != null) {
			Vector2 movement = new Vector2(this.gridStride.x * x, this.gridStride.y * z);
			this.holdingBox.position = this.ClampXZ(this.holdingBox.position + new Vector3(movement.x,0,movement.y) - this.gridOrigin.position);
			return this.holdingBox.position;
		}
		return Vector3.zero;
	}

	private Vector3 ClampXZ(Vector3 origin)
	{
		return new Vector3 (Mathf.Min (Mathf.Max (this.gridMinimum.x, origin.x), this.gridMaximum.x),origin.y, Mathf.Min (Mathf.Max (this.gridMinimum.y, origin.z), this.gridMaximum.y));
	}
}
