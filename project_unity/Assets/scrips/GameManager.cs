using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targetPrefab;

    public float spawnRate = 1.0f;
    public bool gameStarts = true;

    private int score;
    public TextMeshProUGUI scoreText;

    public GameObject gameOver;

    public GameObject MainManu;
    public void Start()
    {
        gameOver.SetActive(false);
    }

    IEnumerator spwanTarget()
    {
        while (gameStarts)
        {
            yield return new WaitForSeconds(spawnRate);
            //生成随机数
            int index = Random.Range(0, targetPrefab.Count);
            Instantiate(targetPrefab[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
        {
            score += scoreToAdd;
            scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameStarts = false;
        gameOver.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//重载（获得名字）
    }

    public void StartNewGame(int difficulty)
    {
        spawnRate /= difficulty;
        score = 0;
        scoreText.text = "Score: " + score;
  
        MainManu.SetActive(false);
        StartCoroutine(spwanTarget());
        
    }
}
