using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform cameraParent;
    [SerializeField]
    Transform cameraSphere;
    [SerializeField]
    Transform viewTarget;
    [SerializeField]
    Transform orbitTarget;
    [SerializeField]
    float camRotateSpeed;
    float camRotation;

    // Start is called before the first frame update
    void Start()
    {
        if (viewTarget == null)
        {
            Debug.LogWarning("No view target for the main camera!");
        }
        if (orbitTarget == null)
        {
            Debug.LogWarning("No orbit target for the main camera!");
        }
        camRotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 gravityUp = (viewTarget.position - orbitTarget.position).normalized;

        Quaternion targetRotation = Quaternion.FromToRotation(cameraSphere.transform.up, gravityUp) * cameraSphere.transform.rotation;
        cameraSphere.transform.rotation = Quaternion.Slerp(cameraSphere.transform.rotation, targetRotation, 50f * Time.deltaTime);

        camRotation -= camRotateSpeed * Input.GetAxis("Mouse X");
        this.transform.localRotation = Quaternion.Euler(0, 0, camRotation);
    }
}
