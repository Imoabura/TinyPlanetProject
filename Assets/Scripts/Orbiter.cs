using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Script controls Orientation/Movement for an Orbiter
[RequireComponent(typeof(Rigidbody))]
public class Orbiter : MonoBehaviour
{
    [SerializeField]
    Transform orbitTarget;  // gameObject to orbit around (E.g., a planet)
    [SerializeField]
    float gravity;          // multiplier of gravity force
    [SerializeField]
    float rotationSmoothing;    //smoothing of rotation

    Rigidbody rb;
    Vector3 gravityUp;      // the vector pointing upwards (Should always be a normalized vector)

    // Start is called before the first frame update
    void Start()
    {
        if (orbitTarget == null)
        {
            Debug.LogWarning("No orbitTarget set!");
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

    public void SetOrbitTarget(Transform target)
    {
        if (target == null)
        {
            Debug.LogWarning("target is null!");
            return;
        }
        orbitTarget = target;
    }

    public Vector3 GetGravityUp()
    {
        return gravityUp;
    }

    // So other scripts don't need reference to RigidBody component
    public void MovePosition(Vector3 moveVector)
    {
        rb.MovePosition(transform.position + moveVector);
    }
}
