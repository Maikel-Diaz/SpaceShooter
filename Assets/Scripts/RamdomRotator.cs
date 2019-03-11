using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdomRotator : MonoBehaviour {

    public float velocityRotate;
    private Rigidbody rig;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
        rig.angularVelocity = Random.insideUnitSphere * velocityRotate;
    }
	
}
