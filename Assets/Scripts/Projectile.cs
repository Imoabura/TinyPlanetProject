using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code to control the Projectile
[RequireComponent(typeof(Orbiter))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    int damage = 1;
    [SerializeField]
    Transform childLocalTransform;

    Orbiter orbiter;
    Rigidbody rb;
    GameObject owner;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        orbiter = GetComponent<Orbiter>();
    }

    private void Update()
    {
        childLocalTransform.forward = -orbiter.GetGravityUp();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HitBox")
        {
            other.gameObject.GetComponent<Planet>().takeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
