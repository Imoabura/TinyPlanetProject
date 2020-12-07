using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Transform mainCam;      // The main Camera
    [SerializeField]
    Transform orbitTarget;  // Transform of the object you're orbiting around
    [SerializeField]
    Transform playerParent;
    [SerializeField]
    float gravity;          // gravity multiplier
    [SerializeField]
    float playerMoveSpeed;  // player movement multiplier

    Rigidbody rb;
    Vector3 moveDirection;
    Vector3 gravityUp;

    // Start is called before the first frame update
    void Start()
    {
        rb = playerParent.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float playerMoveH = Input.GetAxis("Horizontal");
        float playerMoveV = Input.GetAxis("Vertical");
        Vector3 localForward = transform.worldToLocalMatrix.MultiplyVector(transform.forward);
        Vector3 localRight = transform.worldToLocalMatrix.MultiplyVector(transform.right);
        moveDirection = ((playerMoveH * transform.right) + (playerMoveV * transform.forward)).normalized;

        gravityUp = (transform.position - orbitTarget.position).normalized;

        transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, -mainCam.localRotation.eulerAngles.z, transform.localRotation.eulerAngles.z);

        //Debug.DrawRay(transform.position, transform.forward * 20, Color.blue);
        //Debug.DrawRay(transform.position, transform.right * 20, Color.green);
        //Debug.DrawRay(transform.position, localForward * 40, Color.gray);
        //Debug.DrawRay(transform.position, localRight * 40, Color.black);
        //Debug.DrawRay(transform.position, moveDirection * 30, Color.red);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(playerParent.transform.position + moveDirection * playerMoveSpeed);

        Vector3 gravityForce = gravityUp * -gravity;

        rb.AddForce(gravityForce);   // Apply Gravity to Player

        Quaternion targetRotation = Quaternion.FromToRotation(playerParent.transform.up, gravityUp) * playerParent.transform.rotation;
        playerParent.transform.rotation = Quaternion.Slerp(playerParent.transform.rotation, targetRotation, 50f * Time.deltaTime);
    }
}
