using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    [SerializeField]
    int maxHp = 10;
    [SerializeField]
    GameController gameController;
    [SerializeField]
    Slider hpSlider; 

    int currentHp;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        hpSlider.maxValue = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = currentHp;
    }

    public void takeDamage(int amount)
    {
        currentHp -= amount;
        if (currentHp <= 0)
        {
            Debug.Log("dead");
            die();
        }
    }

    void die()
    {
        gameController.gameOver();
    }
}
