using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

    public static float distanceTraveled;

    public float acceleration;

    private bool touchingPlatform;

    public Vector3 boostVelocity, jumpVelocity;

    public float gameOverY;

    private Vector3 startPosition;

    private static int boosts;

	// Use this for initialization
	void Start () {
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        startPosition = transform.localPosition;
        GetComponent<Renderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            if(touchingPlatform)
            {
                GetComponent<Rigidbody>().AddForce(jumpVelocity, ForceMode.VelocityChange);
                touchingPlatform = false;
            }
            else if (boosts > 0)
            {
                GetComponent < Rigidbody>().AddForce(boostVelocity, ForceMode.VelocityChange);
                boosts -= 1;
                GUIManager.SetBoosts(boosts);
            }
        }

        distanceTraveled = transform.localPosition.x;
        GUIManager.SetDistance(distanceTraveled);

        if(transform.localPosition.y < gameOverY)
        {
            GameEventManager.TriggerGameOver();
        }
	
	}

    void FixedUpdate ()
    {
        if(touchingPlatform)
        {
            GetComponent<Rigidbody>().AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
        }
    }

    void OnCollisionEnter ()
    {
        touchingPlatform = true;
    }

    void OnCollisionExit ()
    {
        touchingPlatform = false;
    }

    private void GameStart ()
    {
        boosts = 0;
        GUIManager.SetBoosts(boosts);
        distanceTraveled = 0f;
        GUIManager.SetDistance(distanceTraveled);
        transform.localPosition = startPosition;
        GetComponent<Renderer>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        enabled = true;
    }

    private void GameOver()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        enabled = false;
    }

    public static void AddBoost ()
    {
        boosts += 1;
        GUIManager.SetBoosts(boosts);
    }
}
