using UnityEngine;
using System.Collections;

public class BoxSpawner : MonoBehaviour {

	public Transform camera;
    public Transform boxClone;
	public Transform currentBox;
	public float Zrange;
	public float Xrange;

	// Housekeeping parameters
	private bool hasBox;
	private int currentCameraPosition;

	// Crane parameters
	public float unitSize = 5.0f; // Determines how fast the spawner moves (per second)

	private GridSystemMovement gridSystem;

	private Quaternion defaultRotation = Quaternion.identity;

	public int inputInterval = 0;
	private int inputIntervalCount = 0;

	// Use this for initialization
	private void Start () {
		SpawnBox();
		currentCameraPosition = 0;
		this.gridSystem = this.GetComponent<GridSystemMovement> ();
	}

	
	// Update is called once per frame
	private void FixedUpdate () {
		ProcessInput();
	}

	/// <summary>
	/// Process user input
	/// </summary>
	private void ProcessInput() {
		if ( Input.GetButtonDown( "Drop Box" ) && hasBox ) {
			currentBox.GetComponent<BoxController>().boxRigidBody.isKinematic = false;
			hasBox = false;
			// Wait 1 second before the next box loads
			Invoke( "SpawnBox", 1.0f );
			inputIntervalCount = 0;
		}
		//Rotation camera
		if ( Input.GetButtonDown( "Rotate World" ) ) {
			ChangeCameraOrientation();
		}
		//Reset this level
		if ( Input.GetButtonDown("Escape") ) {
			Application.LoadLevel( "prototype" );
		}

		//Count interval here
		if (inputIntervalCount % inputInterval > 0) {
			inputIntervalCount++;
			return;
		}
		bool movementInput = false;
		if ( Input.GetButton( "Action Up" ) && hasBox ) {
			MoveObjects( new Vector3( 0, 0,unitSize/2f) );
			movementInput = true;
		}

		if ( Input.GetButton( "Action Down" ) && hasBox ) {
			MoveObjects( new Vector3( 0, 0, -unitSize/2f)  );
			movementInput = true;
		}

		if ( Input.GetButton( "Action Left" ) && hasBox ) {
			MoveObjects( new Vector3( unitSize/2f, 0, 0 )  );
			movementInput = true;
		}

		if ( Input.GetButton( "Action Right" ) && hasBox ) {
			MoveObjects( new Vector3(-unitSize/2f, 0, 0 ) );
			movementInput = true;
		}

		if ( Input.GetButton( "Rotate Object Horizontal" ) && hasBox ) {
			RotateObjects(new Vector3(0,1,0));
			movementInput = true;
		}

		if ( Input.GetButton( "Rotate Object Vertical" ) && hasBox ) {
			RotateObjects(new Vector3(0,0,1));
			movementInput = true;
		}
		if (movementInput)
			inputIntervalCount++;
	}

	/// <summary>
	/// Move this spawner and current box holded
	/// </summary>
	/// <param name="movement">translation vector</param>
	private void MoveObjects( Vector3 movement ) {
		//check this movement is in the range
		Vector3 boxSize = currentBox.GetComponent<Collider> ().bounds.size;
		if (boxSize.x / 2f +Mathf.Abs (currentBox.position.x + movement.x) > Xrange || boxSize.z / 2f +  Mathf.Abs (currentBox.position.z + movement.z) > Zrange) {
			return;
		}
		//transform.Translate( movement );
		currentBox.position+=movement;
	}

	/// <summary>
	/// Rotate this spawner and current box holded
	/// </summary>
	/// <param name="rotation">eular rotation vector</param>
	private void RotateObjects(Vector3 rotationAxis ) {
		currentBox.Rotate (rotationAxis, 90f);
	}

	/// <summary>
	/// Move camera position for next position
	/// </summary>
	private void ChangeCameraOrientation() {
		currentCameraPosition = (currentCameraPosition + 1) % 4;
		this.camera.rotation = Quaternion.Euler (30, 45 - this.currentCameraPosition * 90, 0);
		this.camera.position = Matrix4x4.TRS (Vector3.zero, Quaternion.Euler (0, -90 * this.currentCameraPosition, 0), Vector3.one).MultiplyPoint (new Vector3 (-11, 13, -11));
	}

	private void SpawnBox() {
		// Spawn the box
		currentBox = (Transform) Instantiate( boxClone, new Vector3( transform.position.x, transform.position.y, transform.position.z ), Quaternion.identity );
		hasBox = true;
	}
}
