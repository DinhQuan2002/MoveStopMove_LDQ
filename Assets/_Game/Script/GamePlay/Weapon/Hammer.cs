using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon
{
    public bool activated;
    public float rotationSpeed;
    public Rigidbody rb;

    Player Player;

    public void SetTarget(Vector3 position)
    {
        rb.velocity = (position - transform.position);
    }

    private void Start()
    {

    }

    void Update()
    {
    }




    private void OnCollisionEnter(Collision collision)
    {
        //activated = false;
        //GetComponent<Rigidbody>().isKinematic = true;
    }
}
