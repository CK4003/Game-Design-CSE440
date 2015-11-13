using UnityEngine;
using System.Collections;

//using System.Collections.Generic;

public class conveyorController : MonoBehaviour {
	public Transform box;
	private Transform passbox;
	public Transform boxClone;
	System.Collections.Generic.Queue<Transform> conveyor = new System.Collections.Generic.Queue<Transform>();
	public float moveSpeed;
	private Vector3 firstPosition = new Vector3 (0.0f, 8.0f, 6.0f);
	private Vector3 secondPosition = new Vector3 (0.0f, 8.0f, 9.0f);
	private Vector3 thirdPosition = new Vector3 (0.0f, 8.0f, 12.0f);
	private Vector3 moveup = new Vector3 (0.0f, 15.0f, 12.0f);
	private Vector3 endPoint;
	private bool firstpos, secondpos, thirdpos;
	private bool conveyorFull = false;
	private int conveyorCount;
	private float duration = 10.0f;
	private float minAxis = 0.5f;
	private float maxAxis = 2.0f;
	private bool isHoriRotate;
	private bool isVertRotate;
	private bool keypressed;
	private float step;
	public float boxwait;
	public float boxrate;
	// Use this for initialization
	void Start () {
		isHoriRotate = false;
		isVertRotate = false;
		firstpos = false;
		secondpos = false;
		thirdpos = false;
	}
	
	// Update is called once per frame
	void Update () {
		step = moveSpeed * Time.deltaTime;
		Conveyor ();
		//endPoint = firstPosition;
		//box.transform.position = Vector3.MoveTowards(box.transform.position, endPoint, step);
	}
	private void Conveyor(){
		//Spawn box to show on screen. 
		conveyorCount = conveyor.Count;
		if (conveyorCount == 3) {
			conveyorFull = true;
		}
		if (Input.GetKeyDown ("k")) {
			getBox ();
		}
		if(!conveyorFull) {
			SpawnBox();
		}
		updateConveyor ();
	}
	private void updateConveyor(){
		moveBox (1);
		if (Time.time > boxwait) {
			moveBox(2);
			if (Time.time > boxwait * 2){
				moveBox(3);
			}
		}
	}
	private void SpawnBox() {
		// Reset rotation
		if ( isVertRotate ) {
			transform.Rotate( new Vector3( -90, 0, 0 ) );
		}
		if ( isHoriRotate ) {
			transform.Rotate( new Vector3( 0, -90, 0 ) );
		}
		isVertRotate = false;
		isHoriRotate = false;
		// Spawn the box
		box = (Transform)Instantiate (boxClone, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
		box.transform.localScale = new Vector3 (Random.Range (minAxis, maxAxis), Random.Range (minAxis, maxAxis), Random.Range (minAxis, maxAxis));
		box.GetComponent<BoxController>().boxRigidBody.isKinematic = true;
        box.gameObject.GetComponentInChildren<Renderer>().material.color = new Color(0.62f, 0.46f, 0.34f);
		conveyor.Enqueue (box);
	}
	public Transform getBox(){
		conveyorFull = false;
		passbox = conveyor.Dequeue();
		endPoint = moveup;
		passbox.transform.position = endPoint;
		return passbox;
	}
	public void moveBox(int boxno){
		if (boxno == 1) {
			box = conveyor.ToArray()[0];
			endPoint = firstPosition;
		} else if (boxno == 2) {
			box = conveyor.ToArray()[1];
			endPoint = secondPosition;
		}
		else if(boxno == 3){
			box = conveyor.ToArray()[2];
			endPoint = thirdPosition;
		}
		else{
			endPoint = firstPosition;
		}
		box.transform.position = Vector3.MoveTowards(box.transform.position, endPoint, step);
	}
} 