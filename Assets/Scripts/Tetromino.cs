using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    float previousFallTime;
    float fallDelay = 1;
    float previousMoveTime;
    float moveDelay = 0.13f;

    public static int height = 20;
    public static int width = 10;

    public static Transform[,] colliders = new Transform[width, height];

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
            
        if (Time.time - previousFallTime >= ((GameManager.verticalInput == -1) ? fallDelay / 10 : fallDelay))
        {
            transform.position += Vector3.down;
            if (!ValidMove())
            {
                transform.position += Vector3.up;
                AddSelfToColliders();
                CheckForLines();
                this.enabled = false;
                FindObjectOfType<SpawnManager>().SpawnTetromino();
            }
            previousFallTime = Time.time;
        }
    }
    void CheckForLines()
    {
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
            }
        }
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
}
