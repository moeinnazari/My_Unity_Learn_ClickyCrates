using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
     public TextMeshProUGUI scoreText;
     public TextMeshProUGUI gameOverText;
     public Button restartButton;
    public float spawnRate=1f;
    private int score=0;
    private int highScore;
    public bool isGameActive=true;
    public GameObject titleScreen;

    private static GameManager instance=null;
    // Start is called before the first frame update
    void Start()
    {
        if(instance==null)
        {
            instance=this;
        }
     
      titleScreen.gameObject.SetActive(true);
      isGameActive=false;
    }

    public void StartGame(int difficaulty)
    {
        score=PlayerPrefs.GetInt("HighScore");
        PlayerPrefs.SetInt("Score",score);
        spawnRate/=difficaulty;
             isGameActive=true;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    public void GameOver()
    {
        
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        if(PlayerPrefs.HasKey("HighScore"))
        {
             if(PlayerPrefs.GetInt("HighScore") < score)
             {
                PlayerPrefs.SetInt("HighScore",score);
             }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore",score);
        }
        isGameActive=false;

    }

    public void UpdateScore(int scoreToAdd)
    {
        score+=scoreToAdd;
        scoreText.text="Score : "+score;
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
        yield return new WaitForSeconds(spawnRate);
        int index=Random.Range(0,targets.Count);
        Instantiate(targets[index]);    
       
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
