using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    private int score;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive = false;
    public Button restartButton;
    public GameObject titleScreen;
    private AudioSource explosionAudio;
    public AudioClip audioE;
    // Start is called before the first frame update
    void Start()
    {
        explosionAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        explosionAudio.PlayOneShot(audioE);
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            //UpdateScore(5);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        spawnRate /=  difficulty;
        score = 0;
        StartCoroutine("SpawnTarget");
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
}
