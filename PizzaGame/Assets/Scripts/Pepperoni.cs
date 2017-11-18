using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepperoni : MonoBehaviour {

    float timer = 0f;
    public static bool pepperoniExists;
    bool stopped;

    // Use this for initialization
    void Start () {
        pepperoniExists = true;
        stopped = false;
        timer = 0f;
    }

 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Level"))
        {
            stopped = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        }
        if (timer > .1 && other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
        }
    }


    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer > .5 && stopped != true)
        {
            stopped = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        if(timer > 4)
        {
            pepperoniExists = false;
            Destroy(gameObject);
        }
    }
}
