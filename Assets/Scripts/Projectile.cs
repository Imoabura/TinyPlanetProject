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
    float damage;
    [SerializeField]
    Transform childLocalTransform;

    Orbiter orbiter;
    Rigidbody rb;
    GameObject owner;
    Vector3 moveDirection;
    Vector3 localMoveDirection;
    string targetTag;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        orbiter = GetComponent<Orbiter>();
    }

    private void Update()
    {
        childLocalTransform.forward = localMoveDirection;
        moveDirection = childLocalTransform.forward * moveSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        orbiter.MovePosition(moveDirection);
    }

    public void InitializeProjectile(GameObject owner, Vector3 localDirection)
    {
        this.owner = owner;
        this.localMoveDirection = localDirection;
        targetTag = "Player";
    }

    public void InitializeProjectile(GameObject owner, Vector3 localDirection, string tagToHit)
    {
        this.owner = owner;
        this.localMoveDirection = localDirection;
        targetTag = tagToHit;
    }

    public void OnCollisionEnter(Collision collision)
    {
        //if (targetTag == null && collision.gameObject != owner && collision.transform.parent != owner.transform && collision.gameObject.tag != "environment")
        //{
        //    Debug.Log("Do: Something on hitting anything other than owner!");
        //    Destroy(this.gameObject);
        //}
        if (collision.gameObject.tag == targetTag)
        {
            Debug.Log("Do: Something on hit target!");
            Destroy(this.gameObject);
        }
    }
}
