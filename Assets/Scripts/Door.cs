using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public bool open = false;
    float timer = 0f;

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (open)
        {
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            timer += Time.deltaTime;
            if (timer > 6)
            {
                open = true;
                timer = 0f;
            }
        }

    }
}
