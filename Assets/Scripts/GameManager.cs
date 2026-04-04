using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
//////////////////////////////////////////////
//Assignment/Lab/Project: Breakout Game
//Name: Samuel Benson
//Section: SGD.213.0071
//Instructor: Aurore Locklear
//Date: 04/02/2026
/////////////////////////////////////////////
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //Public variables that are used to etheir store values or connecct certain objects to the script.
    public int lives = 3;
    public int bricks = 20;
    public float resetDelay = 1f;
    public TMP_Text livesText;
    public TMP_Text scoreText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
    public GameObject paddle;
    //Private variables that have two int vars to store static values and one gameobject for the paddle clone
    private static int staticLives = 3;
    private static int staticScore = 0;

    private GameObject clonePaddle;
    //On awake this make sure the scene is fresh so all setup functions can run smooth.
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        lives = staticLives;

        Setup();
    }
    //Sets up the paddle clone
    public void Setup()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity);
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
        UpdateUI();
    }
    //Updates the ui
    void UpdateUI()
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;
        if (scoreText != null)
            scoreText.text = "Score: " + staticScore;
    }
    //An update listing for the keycode to skip to the next level
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            LoadNextLevel();
        }
    }
    //Cecks for the game over
    void CheckGameOver()
    {   //The if statment checking for a win 
        if (bricks < 1)
        {
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene != "LevelThreeBenson")
            {
                lives++;
                staticLives = lives;
            }

            if (youWon != null)
                youWon.SetActive(true);

            Time.timeScale = .25f;
            Invoke("LoadNextLevel", resetDelay);
        }
        //If statment checking for a loss
        if (lives < 1)
        {
            if (gameOver != null)
                gameOver.SetActive(true);

            Time.timeScale = .25f;
            staticLives = 3;
            staticScore = 0;
            Invoke("Reset", resetDelay);
        }
    }
    //Loads the next level and checks to see what level we are on. will always go to the level after the one we are on.
    void LoadNextLevel()
    {
        Time.timeScale = 1f;
        staticLives = lives;

        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "LevelOneBenson")
        {
            SceneManager.LoadScene("LevelTwoBenson");
        }
        else if (currentScene == "LevelTwoBenson")
        {
            SceneManager.LoadScene("LevelThreeBenson");
        }
        else
        {
            staticLives = 3;
            staticScore = 0;
            SceneManager.LoadScene("LevelOneBenson");
        }
    }
    //Resets the game back to level one when called
    void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelOneBenson");
    }
    //Method that will reomve a life, update the ui, and check for a game over situation when called when the ball hits the water.
    public void LoseLife()
    {
        lives--;
        staticLives = lives;
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        UpdateUI();
        CheckGameOver();
    }
    //The setup method for the paddle prefab, it will create a clone for it and spawn it.
    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity);
    }
    //Method used to destroy the bricks when called, this will also check for a game over and update the ui, it specificaly will help cause the score ui to go up.
    public void DestroyBrick()
    {
        bricks--;
        staticScore += 100;
        UpdateUI();
        CheckGameOver();
    }
}