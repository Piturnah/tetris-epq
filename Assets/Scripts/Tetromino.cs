using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    [SerializeField] Material[] pallete;

    float previousFallTime;
    float fallDelay = 48f/60f;
    float previousMoveTime;
    float moveDelay = 6f/60f;

    public static int height = 20;
    public static int width = 10;

    public static Transform[,] colliders = new Transform[width, height];

    int softScore;
    
    private void Start()
    {
        DetermineDelay();
    }
    void Update()
    {
        Move();
        Rotate();
    }
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
    void Move()
    {
        if (Time.time - previousMoveTime >= moveDelay)
        {
            transform.position += new Vector3(GameManager.horizontalAxis, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(GameManager.horizontalAxis, 0, 0);
            }
            previousMoveTime = Time.time;
        }
            
        if (Time.time - previousFallTime >= ((GameManager.verticalInput == -1) ? fallDelay / 2 : fallDelay))
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
            if (!ValidMove())
            {
                ScoreManager.score += softScore;
                transform.position += Vector3.up;
                AddSelfToColliders();
                int lines = CheckForLines();
                switch (lines)
                {
                    case 1:
                        ScoreManager.score += 40 * (ScoreManager.level + 1);
                        break;
                    case 2:
                        ScoreManager.score += 100 * (ScoreManager.level + 1);
                        break;
                    case 3:
                        ScoreManager.score += 300 * (ScoreManager.level + 1);
                        break;
                    case 4:
                        ScoreManager.score += 12000 * (ScoreManager.level + 1);
                        break;
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
                ScoreManager.lines += 1;
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
