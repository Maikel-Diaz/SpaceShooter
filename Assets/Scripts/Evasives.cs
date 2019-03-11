using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evasives : MonoBehaviour {

    public Vector2 starWait;
    public float velocityMax;
    private float targetManiobra;
    private Rigidbody rb;
    public float smoothing;
    public Vector2 timeManiobra;
    public Vector2 maniobraWait;
    public float tilt;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start () {
        StartCoroutine(Evade());
	}

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(starWait.x, starWait.y));

        while (true)
        {
            targetManiobra = Random.Range(1, velocityMax) * -Mathf.Sign(transform.position.x);

            yield return new WaitForSeconds(Random.Range(starWait.x, starWait.y));

            targetManiobra = 0;

            yield return new WaitForSeconds(Random.Range(maniobraWait.x, maniobraWait.y));
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManiobra, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(newManeuver, 0f, rb.velocity.z);
        rb.rotation = Quaternion.Euler(0f, 0f, rb.velocity.x * -tilt);
    }
}
