using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject spawnPrefab;
    float timer = 0f;


    // Use this for initialization
    void Start()
    {
        timer = 0;
    }

    void SpawnMe()
    {
        GameObject boolet = (GameObject)Instantiate(spawnPrefab, transform.position, transform.rotation);
        boolet.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            timer += Time.deltaTime;
            if (timer > .15)
            {
                SpawnMe();
                timer = 0;
            }

        }
    }


}
