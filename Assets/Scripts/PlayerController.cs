using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject spawnPrefab;
    public GameObject pepperoni;


    public float moveSpeed;
    public float jumpHeight;
    public float pepperoniTimer;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private int facing = 0;

    float timer = 0f;
    float delay = 0f;

    // Use this for initialization
    void Start () {
		
	}

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void SpawnBoolet()
    {
        GameObject boolet = (GameObject)Instantiate(spawnPrefab, transform.position, transform.rotation);
        if (facing == 0)
        {
            boolet.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        }
        else if (facing == 1)
        {
            boolet.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
        }
        else if(facing == 2)
        {
            boolet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,10);
        }else if(facing == 3)
        {
            boolet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10);

        }

    }

    void SpawnPepperoni()
    {
        GameObject pepperoniShoot = (GameObject)Instantiate(pepperoni, new Vector3(transform.position.x, transform.position.y+.5f, transform.position.z), transform.rotation);
        if (facing == 0)
        {
            pepperoniShoot.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        }
        else if (facing == 1)
        {
            pepperoniShoot.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
        }
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.B))
        {
            if (!Pepperoni.pepperoniExists){
                SpawnPepperoni();
            }
        }

        if (Input.GetKey(KeyCode.V))
        {
                timer += Time.deltaTime;
            

                if (timer >= .15)
                {
                    timer = 0;
                }
                if (timer == 0)
                {
                    SpawnBoolet();
                }
            
        }
        if(Input.GetKeyUp(KeyCode.V))
        {
            timer = 0;
            delay = Time.time;
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            if(Time.time - delay > .15)
            {
                SpawnBoolet();
            }
        }
        if (Input.GetKeyDown(KeyCode.C) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            facing = 3;
        }
        else if (Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            facing = 0;
        }else if (Input.GetKey(KeyCode.A) ||
           Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            facing = 1;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            facing = 2;
        }
       
    }
}
