using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    [Header("Movimiento")]
    public float speed;
    public float tilt;
    public Boundary limit;
    private Rigidbody rig;

    [Header("Disparo")]
    public GameObject shot;
    public Transform shotSpawn_left;
    public Transform shotSpawn_right;
    public float fireRate;
    private float nextFire;

	// Use this for initialization
	void Awake () {
        rig = GetComponent<Rigidbody>();

	}
    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn_left.position, Quaternion.identity);
            Instantiate(shot, shotSpawn_right.position, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void FixedUpdate () {
        float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rig.velocity = movement * speed;
        rig.position = new Vector3(Mathf.Clamp(rig.position.x, limit.xMin, limit.xMax), 0f, Mathf.Clamp(rig.position.z, limit.zMin, limit.zMax));
        rig.rotation = Quaternion.Euler(0f, 0f, rig.velocity.x * -tilt);


    }
}
