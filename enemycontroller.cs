using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontroller : MonoBehaviour {
    public float speed;
    public Transform player;
    public int health;
    
 
    // Use this for initialization

	void Start () {
        speed = 10;
        player = GameObject.Find("player").transform;
        health = 5;
		
	}
	
	// Update is called once per frame
	void Update () {
        float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, z);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bullet")
        {
            health -= 1;
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                Destroy(gameObject);
                
            }

        }

    }
}
