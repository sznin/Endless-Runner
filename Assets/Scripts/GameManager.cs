using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject player;

    public GameObject ParallaxManager;

    public bool isPlaying;

    public float currentScore;

    public int currentCollected;
    public List<GameObject> activeObstacles;

    public float currentObstacleSpeed;
    public float maxObstacleSpeed;
    public float acceleration = 0.1f;

    public bool canSpawn = true;

    public bool isCrouched = false;


    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    public string ScoreDisplay()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying == true && !isCrouched)
        {
            currentScore += Time.deltaTime;


            if(currentObstacleSpeed < maxObstacleSpeed )
            {
                currentObstacleSpeed += acceleration = Time.deltaTime;
                ResumeObstacles();
            }


            
        }

        if(Input.GetKeyDown("r"))
        {
            
            if(isPlaying == true)
            {
                ResetGame();
            }
            else
            {
                ResetGame();
                UserInterfaceManager.Instance.GameOverDisplay();
            }
        }
    }

    public void GameOver()
    {
        
        isPlaying = false;
        UserInterfaceManager.Instance.GameOverDisplay();
    }

    public void ResetGame()
    {
        isPlaying = true;
        currentScore = 0;
        player.SetActive(true);
        currentCollected = 0;
        foreach (GameObject go in activeObstacles)
        {
            Destroy(go);
        }

        activeObstacles.Clear();
        ResumeObstacles();
    }

    public void PauseObstacles()
    {
        foreach (GameObject obstacle in activeObstacles)
        {
            Rigidbody2D obstacleRB = obstacle.GetComponent<Rigidbody2D>();
            obstacleRB.velocity = Vector2.left * 0;

        }
        canSpawn = false;
    }

    public void ResumeObstacles()
    {
        foreach (GameObject obstacle in activeObstacles)
        {
            Rigidbody2D obstacleRB = obstacle.GetComponent<Rigidbody2D>();
            obstacleRB.velocity = Vector2.left * currentObstacleSpeed;
        }
        canSpawn = true;
    }
}
