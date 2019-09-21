using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tetromino : MonoBehaviour
{
    [SerializeField] Material[] pallete;

    float previousFallTime;
    float fallDelay = 48f/60f;
    float previousMoveTime;
    float moveDelay = 6f/60f;

    public static int height = 20;
    public static int width = 10;

    public static event Action deathEvent;
    public static event Action<int> updateScore;
    public static event Action updateLines;

    public static Transform[,] colliders = new Transform[width, height];

    int softScore;
    
    public static void ResetActions()
    {
        updateScore = null;
        updateLines = null;
    }
    private void Start()
    {
        DetermineDelay();
    }
    void Update()
    {
        //Update the tetronimo's position and rotation each frame
        Move();
        Rotate();
    }
    //Rotate the tetronimo according to input
    void Rotate()
    {
        Vector3 pivot = transform.GetChild(0).transform.position;
        foreach (Transform child in transform)
        {
            transform.RotateAround(pivot, Vector3.forward, GameManager.rotationAxis * -90);
        }
        if (!ValidMove())
        {
            foreach (Transform child in transform)
            {
                transform.RotateAround(pivot, Vector3.forward, GameManager.rotationAxis * 90);
            }
        }
    }
    //Move the tetronimo horizontally, + softdropping, according to input
    void Move()
    {
        //Check if the tetronimo should be able to move horizontally yet
        if (Time.time - previousMoveTime >= moveDelay)
        {
            //If it is, check if receiving horizontal input
            transform.position += new Vector3(GameManager.horizontalAxis, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(GameManager.horizontalAxis, 0, 0);
            }
            previousMoveTime = Time.time;
        }

        //Check if tetronimo should fall yet and handle that
        if (Time.time - previousFallTime >= ((GameManager.verticalInput == -1) ? 2f/60f : fallDelay))
        {
            transform.position += Vector3.down;
            if (GameManager.verticalInput == -1)
            {
                softScore += 1;
                if (!ValidMove())
                {
                    softScore -= 1;
                }
            }
            //Check if tetronimo has landed on a surface
            if (!ValidMove())
            {
                //If the tetronimo is at the top of the board, end the game
                if (transform.position.y >= 18)
                {
                    if (deathEvent != null)
                    {
                        deathEvent();
                    }
                    GameManager.gameRunning = false;
                }
                //Deal with scoring and add the tetronimo's colliders
                transform.position += Vector3.up;
                AddSelfToColliders();
                int lines = CheckForLines();
                int addScore = softScore;
                switch (lines)
                {
                    case 1:
                        addScore = 40;
                        break;
                    case 2:
                        addScore = 100;
                        break;
                    case 3:
                        addScore = 300;
                        break;
                    case 4:
                        addScore = 1200;
                        break;
                }
                if (updateScore != null)
                {
                    updateScore(addScore);
                }
                this.enabled = false;
                FindObjectOfType<SpawnManager>().SpawnTetromino();
            }
            previousFallTime = Time.time;
        }
    }
    int CheckForLines()
    {
        int lines = 0;
        for (int y = height - 1; y >= 0; y--)
        {
            if (CheckRow(y))
            {
                for (int x = 0; x < width; x++)
                {
                    Destroy(colliders[x, y].gameObject);
                    colliders[x, y] = null;
                }
                Fall(y);
                if (updateLines != null)
                {
                    updateLines();
                }
                lines += 1;
            }
        }
        return lines;
    }
    bool CheckRow(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if (colliders[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }
    void Fall(int row)
    {
        for (int y = row + 1; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (colliders[x,y] != null)
                {
                    colliders[x, y - 1] = colliders[x, y];
                    colliders[x, y] = null;
                    colliders[x, y - 1].position += Vector3.down;
                }
            }
        }
    }
    void AddSelfToColliders()
    {
        foreach (Transform child in transform)
        {
            if (child.GetSiblingIndex() != 0)
            {
                int roundedX = Mathf.RoundToInt(child.transform.position.x);
                int roundedY = Mathf.RoundToInt(child.transform.position.y);

                colliders[roundedX, roundedY] = child;
            }
        }
    }
    bool ValidMove()
    {
        foreach (Transform child in transform)
        {
            if (child.GetSiblingIndex() != 0)
            {
                int roundedX = Mathf.RoundToInt(child.transform.position.x);
                int roundedY = Mathf.RoundToInt(child.transform.position.y);

                if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
                {
                    return false;
                }
                if (colliders[roundedX, roundedY] != null)
                {
                    return false;
                }
            }
            
        }

        return true;
    }
    //Set the falling speed of the tetronimo
    void DetermineDelay()
    {
        switch (ScoreManager.level)
        {
            
            case 0:
                fallDelay = 48f / 60f;
                break;
            case 1:
                fallDelay = 43f / 60f;
                break;
            case 2:
                fallDelay = 38f / 60f;
                break;
            case 3:
                fallDelay = 33f / 60f;
                break;
            case 4:
                fallDelay = 28f / 60f;
                break;
            case 5:
                fallDelay = 23f / 60f;
                break;
            case 6:
                fallDelay = 18f / 60f;
                break;
            case 7:
                fallDelay = 13f / 60f;
                break;
            case 8:
                fallDelay = 8f / 60f;
                break;
            case 9:
                fallDelay = 6f / 60f;
                break;
            case 10:
            case 11:
            case 12:
                fallDelay = 5f / 60f;
                break;
            case 13:
            case 14:
            case 15:
                fallDelay = 4f / 60f;
                break;
            case 16:
            case 17:
            case 18:
                fallDelay = 3f / 60f;
                break;
            case 19:
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
            case 25:
            case 26:
            case 27:
            case 28:
                fallDelay = 2f / 60f;
                break;
            default:
                fallDelay = 1f / 60f;
                break;
        }
    }
}
