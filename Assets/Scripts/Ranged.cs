using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Orbiter))]
public class Ranged : MonoBehaviour
{
    [SerializeField]
    GameObject projectilePrefab;    // The projectile prefab
    [SerializeField]
    Transform spawnLoc;             // location to spawn projectile
    [SerializeField]
    Transform target;               // target to shoot at

    Orbiter orbiter;

    // Start is called before the first frame update
    void Start()
    {
        orbiter = GetComponent<Orbiter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))   // FOR TESTING ONLY
        {
            Fire();
        }
    }

    // Fire the projectile
    public void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, spawnLoc.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().InitializeProjectile(this.gameObject, GetTargetDirection());
    }

    public Vector3 GetTargetDirection()
    {
        if (target != null)
        {
            Vector3 VectorToTarget = (target.position - transform.position).normalized;
            return (VectorToTarget + orbiter.GetGravityUp()).normalized;
        }
        return transform.forward;
    }
}
