using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boolet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 2);
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Level")){
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
           // Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Door"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
