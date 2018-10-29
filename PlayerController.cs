using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 5;
    public int score = 0;
    GameObject bulletPrefab;
	// Use this for initialization
	void Start () {
        bulletPrefab = GameObject.Find("bullet");
	}
	
	// Update is called once per frame
	void Update () {
        //First handle player rotation
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        //Next handle x y
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        float h = 3.0f * Input.GetAxis("Mouse X");
        float v = 3.0f * Input.GetAxis("Mouse Y");
        transform.Rotate(v, 0, 0);
        transform.Translate(x, y, 0);

        //Now handle projectile firing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
	}
     
    void Fire()
    {
        var barrel = transform.Find("barrel").transform;
        GameObject bullet = Instantiate(bulletPrefab, barrel.transform.position, Quaternion.identity) as GameObject;

        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 300);
        Destroy(bullet, 2);

    }
}
