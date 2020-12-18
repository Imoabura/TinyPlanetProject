using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Transform planet;
    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    int planetMaxHp = 10;

    [SerializeField]
    int enemiesPerWave = 1;
    [SerializeField]
    int delayTime = 10;
    [SerializeField]
    int spawnDist = 25;

    float timer = 0;
    int enemiesKilled = 0;  //needs to be updated by Enemy.cs
    int waveCount = 0;
    int planetCurrentHp;

    // Start is called before the first frame update
    void Start()
    {
        planetCurrentHp = planetMaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delayTime)
        {
            timer = 0;
            spawnEnemies();
        }
    }

    void spawnEnemies()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, generateRandomLoc(), Quaternion.identity);
        }
        waveCount++;
    }

    void gameOver()
    {
        Debug.Log("Game Over!!!");
    }

    Vector3 generateRandomLoc()
    {
        Vector3 result = new Vector3();
        for (int i = 0; i < 3; i++)
        {
            float temp = Random.Range(-1.0f, 1.0f);
            result[i] = temp;
        }
        Debug.Log(result);
        result = result.normalized * spawnDist;
        Debug.Log(result);
        return result;
    }
}
