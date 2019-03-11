using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public float timeInic;
    public float fireRate;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Fire", timeInic, fireRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }
}
