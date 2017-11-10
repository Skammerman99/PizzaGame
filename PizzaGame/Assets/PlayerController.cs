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

    float timer = 0f;


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
        boolet.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);

    }

    void SpawnPepperoni()
    {
        GameObject pepperoniShoot = (GameObject)Instantiate(pepperoni, transform.position, transform.rotation);
        pepperoniShoot.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
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
            if (timer > .15)
            {
                SpawnBoolet();
                timer = 0;
            }

        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
        }
        if (Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(KeyCode.A) ||
           Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
