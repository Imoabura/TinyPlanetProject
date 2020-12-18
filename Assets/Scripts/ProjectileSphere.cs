using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSphere : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed;
    [SerializeField]
    Transform localTransform;
    [SerializeField]
    Transform parentTransform;

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
        transform.up = gravityUp;
        parentTransform.forward = localDirection;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(parentTransform.position, parentTransform.forward * 20, Color.black);

        float stepSize = rotateSpeed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.up, parentTransform.forward, stepSize, 0.0f);

        Debug.DrawRay(transform.position, parentTransform.forward * 50, Color.green);
        Debug.DrawRay(transform.position, newDirection * 50, Color.blue);

        // This avoids the issue of setting directional vectors directly
        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, newDirection) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 50 * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        
    }
}
