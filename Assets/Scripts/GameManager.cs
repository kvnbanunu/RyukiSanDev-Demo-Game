using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float enemyY = 7;
    public GameObject[] enemy;
    private float xBoundary = 9.6f;
    public static float spawnRate = 0.5f;
    public float minSpawnRate = 0.001f;
    public float decreaseRate = 0.001f;
    public float decreaseInterval = 0.1f;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public bool gameRunning;
    public Enemy enemyForce;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, spawnRate); // Repeating spawn enemy
        StartCoroutine(DecreaseSpawnRateOverTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Custom Function to Spawn enemy at random x location
    private void SpawnEnemy()
    {
        float xPOS = Random.Range(-xBoundary, xBoundary);
        int index = Random.Range(0, enemy.Length);
        Instantiate(enemy[index], new Vector3(xPOS, enemyY), enemy[index].transform.rotation);
    }
    public void UpdateScore(int addend)
    {
        if (gameRunning)
        {
            score += addend;
            scoreText.SetText("Score: " + score);
        }

    }
    public void RestartGame()
    {
        spawnRate = 0.5f;
        enemyForce.resetForce();
        SceneManager.LoadScene(0);
    }
    public void QuitApp()
    {
        Application.Quit();
    }
    IEnumerator DecreaseSpawnRateOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(decreaseInterval);
            if (spawnRate > minSpawnRate)
            {
                spawnRate -= decreaseRate;
                CancelInvoke("SpawnEnemy");
                InvokeRepeating("SpawnEnemy", 1, spawnRate);
            }
        }
    }
}
