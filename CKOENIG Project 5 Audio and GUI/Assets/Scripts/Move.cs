using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Move : MonoBehaviour {

    // Variables for movement
    private Vector3 mousePosition;
    private float speed;
    private bool canJump;

    // Variables for scoring
    public static int score;
    Text text;

    // Use this for initialization
    void Start () {
        speed = 1.0f;
        canJump = true;

        text = GetComponent<Text>();
        score = 0;
    }
	
	// Update is called once per frame
	void Update () {

        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;

        if (canJump && Input.GetKey("up") || 
            canJump && Input.GetKey("left") && Input.GetKey("up") || 
            canJump && Input.GetKey("right") && Input.GetKey("up"))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500f);
            canJump = false;
            score++;
        }
        text.text = "Your Score: " + score;
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
