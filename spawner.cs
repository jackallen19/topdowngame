using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
    public Transform prefab;
    public float spawntime = 3f;

	// Use this for initialization
	void Start () {

        InvokeRepeating("Spawn", spawntime, spawntime);
		
	}
    void Spawn()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
        Instantiate(prefab, transform.position, Quaternion.identity);

    }


}
