using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool isGameActive;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button InGameRestart;
    public Button exitButton;
    public GameObject player;
    private float startPosX = -11.5f;
    private float startPosY = -0.8f;
    // Start is called before the first frame update
    void Start()
    {
       isGameActive = false;
       restartButton.onClick.AddListener(RestartGame);
        InGameRestart.onClick.AddListener(RestartGame);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive = true;
        player.transform.position = new Vector3(startPosX, startPosY);
      
    }

}
