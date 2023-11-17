using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gamecontroller : MonoBehaviour
{
    public GameObject cube;

    public Transform position;
    public Text scoreText;
    public Text healthText;
    public TMP_Text gameStatusText;
    public TMP_Text currentLevelText;

    private int score = 0;
    private float health = 100.0f;
    private int currentLevel = 1;

    // Start is called before the first frame update
    // Public variables
    public int playerScore = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (score >= 100)
        {
            scoreText.text = "Score is " + score + " You have won!";

        }
        else
        {
            scoreText.text = "Score: " + score;

        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            //score = score + 10;
            score += 10;
        }

        if (health <= 0)
        {
            healthText.text = "Health: " + health;
            gameStatusText.text = "GAME OVER";
        }
        else
        {
            healthText.text = "Health: " + health;

        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            health -= 10;
        }

        if (score == 100)
        {
            currentLevel += 1;
            gameStatusText.text = "You are on the next level " + currentLevel;
            score = 0;

        }
        currentLevelText.text = "You are on level " + currentLevel;

    }

    public void IncreaseScore(int increaseScoreBy)
    {
        score += increaseScoreBy;
        scoreText.text = "Score: " + score;
        print("IncreaseScore" + score);
    }

}