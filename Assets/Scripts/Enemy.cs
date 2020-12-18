using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Transform spawnLoc;
    [SerializeField]
    GameObject projectilePrefab;
    [SerializeField]
    GameController gameController;

    Orbiter orbiter;

    [SerializeField]
    int health;
    [SerializeField]
    int shootCooldown;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        orbiter = GetComponent<Orbiter>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootCooldown && !gameController.isGameOver())
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, spawnLoc.position, Quaternion.identity);
        projectile.transform.forward = -orbiter.GetGravityUp();
    }

    public void takeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            die();
        }
    }

    private void die()
    {
        GameObject.Find("GameController").GetComponent<GameController>().enemyKilled();
        Destroy(this.gameObject);
    }
}
