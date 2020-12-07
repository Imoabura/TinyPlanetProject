using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroys this object depending on lifetime in seconds. Mainly for projectiles.
public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField]
    float seconds;

    // Update is called once per frame
    void Update()
    {
        seconds -= Time.deltaTime;
        if (seconds <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
