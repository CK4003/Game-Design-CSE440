using UnityEngine;
using System.Collections;

public class JumpAudio : MonoBehaviour {

    public AudioClip Jump;
    private AudioSource source;

	// Use this for initialization
	void Awake () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("up"))
        {
            source.PlayOneShot(Jump);
        }
	
	}
}
