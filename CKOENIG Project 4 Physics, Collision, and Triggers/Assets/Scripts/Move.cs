using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    private Vector3 mousePosition;
    private float speed;
    private bool canJump;

    // Use this for initialization
    void Start () {
        speed = 1.0f;
        canJump = true;
	
	}
	
	// Update is called once per frame
	void Update () {

        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;

        if (canJump && Input.GetKeyDown("up") || 
            canJump && Input.GetKeyDown("left") && Input.GetKeyDown("up") || 
            canJump && Input.GetKeyDown("right") && Input.GetKeyDown("up"))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500f);
            canJump = false;
        }

        if (Input.GetMouseButton(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, speed);
        }

        
    }

    void OnCollisionEnter2D()
    {
        canJump = true;
    }

    void OnCollisionExit2D()
    {
        canJump = false;
    }
}
