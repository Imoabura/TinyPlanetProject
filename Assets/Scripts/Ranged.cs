using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Orbiter))]
public class Ranged : MonoBehaviour
{
    [SerializeField]
    GameObject projectilePrefab;    // The projectile prefab

    Orbiter orbiter;
    Transform localTransform;

    // Start is called before the first frame update
    void Start()
    {
        orbiter = GetComponent<Orbiter>();
        localTransform = transform.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))   // FOR TESTING ONLY
        {
            Fire();
        }
        Debug.DrawRay(localTransform.position, localTransform.forward * 20, Color.red);
    }

    // Fire the projectile
    public void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, Vector3.zero, Quaternion.identity);
        projectile.GetComponent<ProjectileSphere>().InitializeProjectile(orbiter.GetOrbitTarget(), localTransform.forward, orbiter.GetGravityUp());
    }
}
