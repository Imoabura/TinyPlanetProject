using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Transform planet;
    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    int enemiesPerWave = 1;
    [SerializeField]
    int delayTime = 10;
    [SerializeField]
    int spawnDist = 25;

    [SerializeField]
    GameObject planetUI;
    [SerializeField]
    GameObject gameOverScreen;
    [SerializeField]
    TextMeshProUGUI waveCountField;
    [SerializeField]
    TextMeshProUGUI enemiesKilledField;

    float timer = 0;
    int enemiesKilled = 0;  //needs to be updated by Enemy.cs
    int waveCount = 0;

    bool gameIsOver = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delayTime && !gameIsOver)
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

    public bool isGameOver()
    {
        return gameIsOver;
    }

    public void gameOver()
    {
        Debug.Log("Game Over!!!");
        gameIsOver = true;
        planetUI.SetActive(false);
        gameOverScreen.SetActive(true);
        waveCountField.text = waveCount.ToString();
        enemiesKilledField.text = enemiesKilled.ToString();
    }

    public void enemyKilled()
    {
        enemiesKilled++;
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

    public void reload()
    {
        SceneManager.LoadScene(0);
    }
}
