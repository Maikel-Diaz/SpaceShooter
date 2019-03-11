using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] peligros;
    public Vector3 spawnValues;
    public int totalPeligros;
    public float spawnWait;
    public float startWait;
    public float hordasWait;

    private int score;
    public Text scoreText;

    public GameObject restartGameObject;
    public GameObject gameOverGameObject;
    private bool showRestart;
    private bool showGameOver;

	// Use this for initialization
	void Start () {
        score = 0;
        showRestart = false;
        showGameOver = false;
        restartGameObject.gameObject.SetActive(false);
        gameOverGameObject.gameObject.SetActive(false);
        UpdateScore();
        StartCoroutine(InstantiatePeligros());
    }

    void Update()
    {
        if(restartGameObject && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    IEnumerator InstantiatePeligros () {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < totalPeligros; i++)
            {
                GameObject peligro = peligros[Random.Range(0, peligros.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(peligro, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(hordasWait);

            if(showGameOver)
            {
                restartGameObject.gameObject.SetActive(true);
                showRestart = true;
                break;
            }
        }
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();

    }

    void UpdateScore() {
        scoreText.text = "Score: " + score;

    }


    public void GameOver()
    {
        gameOverGameObject.gameObject.SetActive(true);
        showGameOver = true;
    }
}
