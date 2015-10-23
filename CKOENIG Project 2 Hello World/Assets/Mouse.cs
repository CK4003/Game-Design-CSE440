using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("1", typeof(Sprite)) as Sprite;
        }
       
    }

    void OnMouseDown ()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("1", typeof(Sprite)) as Sprite;
    }


}
