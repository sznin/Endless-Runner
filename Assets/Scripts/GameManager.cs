using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton definition

    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    #endregion

    public GameObject player;

    public bool isPlaying;

    public float currentScore;

    public int currentCollected;
    public List<GameObject> activeObstacles;

    public float currentObstacleSpeed;
    public float maxObstacleSpeed;

    public bool canSpawn = true;

    
    public string ScoreDisplay()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying == true)
        {
            currentScore += Time.deltaTime;
        }

        if(Input.GetKeyDown("j"))
        {
            ResetGame();
        }
    }

    public void GameOver()
    {
        currentScore = 0;
        isPlaying = false;
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
