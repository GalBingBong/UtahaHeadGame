using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Drawing;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform[] enemySpwanPoints;
    public GameObject[] enemies;
    int enemiesIndex;
    int enemySpwanPointIndex;

    public float minSec;
    public float maxSec;

    [SerializeField]
    public bool gameLive;
   public float gameTime;
    float WaitSec;
    public int Point;

    public Button startButton;
    public Text gameOverText;
    public Text pointText;
    private bool gameStarted = false;

    void Awake()
    {
        instance = this;
        StartCoroutine(Spawn());

        Time.timeScale = 0f;
        


    }

    void Update()
    {
        pointText.text = "Point :" + Point;
        gameTime += Time.deltaTime;
       // StartCoroutine(Spawn());

    }

    IEnumerator Spawn()
    {
        while (true)
        {
            float a = Point * 0.0002f;
            WaitSec = Random.Range(minSec, maxSec - a);
            yield return new WaitForSeconds(WaitSec);
            int enemySpawnPointIndex = Random.Range(0, enemySpwanPoints.Length);
            int enemiesIndex = Random.Range(0, enemies.Length);

            Instantiate(enemies[enemiesIndex], enemySpwanPoints[enemySpawnPointIndex].position, enemySpwanPoints[enemySpawnPointIndex].rotation);

        }

    }

    public void StartGame()
    {
        Point = 0;
        gameOverText.gameObject.SetActive(false);
        gameLive = true;
        gameStarted = true; 
        Time.timeScale = 1f;
        startButton.gameObject.SetActive(false);
    }

    public void StopGame()
    {
        gameOverText.gameObject.SetActive(true);
        gameLive = false;
        gameStarted = false;
        Time.timeScale = 0f;
        startButton.gameObject.SetActive(true);
    }
}



