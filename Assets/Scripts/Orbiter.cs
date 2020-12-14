using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Script controls Orientation/Movement for an Orbiter
[RequireComponent(typeof(Rigidbody))]
public class Orbiter : MonoBehaviour
{
    public Transform orbitTarget;  // gameObject to orbit around (E.g., a planet)
    [SerializeField]
    float gravity = 12;          // multiplier of gravity force
    [SerializeField]
    float rotationSmoothing = 50;    //smoothing of rotation

    Rigidbody rb;
    Vector3 gravityUp;      // the vector pointing upwards (Should always be a normalized vector)

    // Start is called before the first frame update
    void Start()
    {
        if (orbitTarget == null)
        {
            Debug.LogWarning("No orbitTarget set!");
            orbitTarget = GameObject.Find("Planetary Body").transform;
        }
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        gravityUp = (transform.position - orbitTarget.transform.position).normalized;
    }

    private void FixedUpdate()
    {
        rb.AddForce(gravityUp * -gravity);  // Apply Gravity

        // Fix Rotation of 
        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, gravityUp) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothing * Time.deltaTime);
    }

    // Sets the target to orbit around
    public void SetOrbitTarget(Transform target)
    {
        if (target == null)
        {
            Debug.LogWarning("target is null!");
            return;
        }
        orbitTarget = target;
    }

    // Gets the gravityUp
    public Vector3 GetGravityUp()
    {
        return gravityUp;
    }

    // So other scripts don't need reference to RigidBody component
    public void MovePosition(Vector3 moveVector)
    {
        rb.MovePosition(transform.position + moveVector);
    }

    public Transform GetOrbitTarget()
    {
        return orbitTarget;
    }
}
