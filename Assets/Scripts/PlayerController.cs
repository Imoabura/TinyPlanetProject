using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Player Controller Script! Should handle all player key inputs.
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Transform mainCam;      // The main Camera
    [SerializeField]
    float playerMoveSpeed;  // player movement multiplier

    Orbiter orbiter;        // Orbiter Script
    Vector3 moveDirection;

    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        orbiter = GetComponentInParent<Orbiter>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerMoveH = Input.GetAxis("Horizontal");
        float playerMoveV = Input.GetAxis("Vertical");

        if (!gameController.isGameOver())
        {
            moveDirection = ((playerMoveH * transform.right) + (playerMoveV * transform.forward)).normalized;

            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, -mainCam.localRotation.eulerAngles.z, transform.localRotation.eulerAngles.z);
        }
        // Debugging rays
        //Debug.DrawRay(transform.position, transform.forward * 20, Color.blue);
        //Debug.DrawRay(transform.position, transform.right * 20, Color.green);
        //Debug.DrawRay(transform.position, moveDirection * 30, Color.red);
    }

    private void FixedUpdate()
    {
        orbiter.MovePosition(moveDirection * playerMoveSpeed);
    }
}
