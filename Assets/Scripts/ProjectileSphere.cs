using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSphere : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed;
    [SerializeField]
    Transform localTransform;

    Transform orbitTarget;
    Vector3 localMoveDirection;
    Vector3 gravityUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InitializeProjectile(Transform orbitTarget, Vector3 localDirection, Vector3 gravityUp)
    {
        this.orbitTarget = orbitTarget;
        localMoveDirection = localDirection;
        transform.up = gravityUp;
    }

    // Update is called once per frame
    void Update()
    {
        localTransform.forward = localMoveDirection;
        float stepSize = rotateSpeed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.up, localMoveDirection, stepSize, 0.0f);

        Debug.DrawRay(transform.position, newDirection * 50, Color.blue);

        transform.up = newDirection;
    }

    private void FixedUpdate()
    {
        
    }
}
