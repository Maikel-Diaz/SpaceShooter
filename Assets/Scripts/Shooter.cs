using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public float speed;
    private Rigidbody rig;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }


    // Use this for initialization
    void Start () {
        rig.velocity = transform.forward * speed;
	}
	
}
