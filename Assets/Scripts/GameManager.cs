using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static Tetrominoes tetros = new Tetrominoes();
    public static int startLevel = 0;
    public static int topScore;

    public static float horizontalInput = 0;
    public static float verticalInput = 0;
    public static float rotateInput = 0;

    public static float horizontalAxis = 0;
    public static float verticalAxis = 0;
    public static float rotationAxis = 0;

    float previousFallTime;
    float fallDelay = 1f;

    public static event Action startGame;

    public static bool gameRunning = false;

    public void StartGame()
    {
        if (startGame != null)
        {
            startGame();
        }
        Tetromino.deathEvent += OnPlayerDeath;

        gameRunning = true;
        SceneManager.LoadScene(2);

        //Increase starting level by 10 if user holds space while starting
        if (Input.GetKey(KeyCode.Z))
        {
            startLevel += 10;
        }
        //Initialise ScoreManager values
        ScoreManager.startLevel = startLevel;
        ScoreManager.level = startLevel;
        ScoreManager.score = 0;
        ScoreManager.lines = 0;
        ScoreManager.topScore = topScore;

        GameObject other = FindObjectOfType<GameManager>().gameObject;
        if (other != null)
        {
            Destroy(other);
        }
    }
    private void OnPlayerDeath()
    {
        //Load the level select scene and replace that scene's existing GameManager
        SceneManager.LoadScene(1);
        GameObject other = FindObjectOfType<GameManager>().gameObject;
        if (other != null)
        {
            Destroy(other);
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        tetros.ResetCounters();
    }
    private void Update()
    {
        DetectInput();
    }
    void DetectInput()
    {
        horizontalAxis = 0;
        verticalAxis = 0;
        rotationAxis = 0;

        horizontalAxis = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            rotationAxis = Input.GetAxisRaw("Rotate");
        }
    }
    //Struct storing information about how many of each tetronimo has been dropped
    public struct Tetrominoes
    {
        public int totalTetrominoes;
        public int tTetrominoes;
        public int jTetrominoes;
        public int zTetrominoes;
        public int oTetrminoes;
        public int sTetrominoes;
        public int lTetrominoes;
        public int iTetrominoes;

        //Reset counters to initial value (0)
        public void ResetCounters()
        {
            totalTetrominoes = tTetrominoes = jTetrominoes
                = zTetrominoes = oTetrminoes = sTetrominoes = lTetrominoes = iTetrominoes = 0;
        }
    }
}
