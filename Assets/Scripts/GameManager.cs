using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Tetrominoes tetros = new Tetrominoes();

    public static float horizontalInput = 0;
    public static float verticalInput = 0;
    public static float rotateInput = 0;

    public static float horizontalAxis = 0;
    public static float verticalAxis = 0;
    public static float rotationAxis = 0;

    float previousFallTime;
    float fallDelay = 1f;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        StartGame();
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
    public static void StartGame()
    {
        tetros.ResetCounters();
    }
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

        public void ResetCounters()
        {
            totalTetrominoes = tTetrominoes = jTetrominoes
                = zTetrominoes = oTetrminoes = sTetrominoes = lTetrominoes = iTetrominoes = 0;
        }
    }
}
