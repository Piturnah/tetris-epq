using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] tetrominoes;
    public static GameObject nextTetromino;
    GameObject nextImage;

    private void Start()
    {
        nextTetromino = tetrominoes[Random.Range(0, tetrominoes.Length)];
        SpawnTetromino();
    }
    public void SpawnTetromino()
    {
        if (GameManager.gameRunning)
        {
            Instantiate(nextTetromino, transform.position, transform.rotation, transform);
            switch (nextTetromino.name)
            {
                case "I-Tetromino":
                    GameManager.tetros.iTetrominoes += 1;
                    break;
                case "J-Tetromino":
                    GameManager.tetros.jTetrominoes += 1;
                    break;
                case "L-Tetromino":
                    GameManager.tetros.lTetrominoes += 1;
                    break;
                case "O-Tetromino":
                    GameManager.tetros.oTetrminoes += 1;
                    break;
                case "S-Tetromino":
                    GameManager.tetros.sTetrominoes += 1;
                    break;
                case "T-Tetromino":
                    GameManager.tetros.tTetrominoes += 1;
                    break;
                case "Z-Tetromino":
                    GameManager.tetros.zTetrominoes += 1;
                    break;
            }
            GameManager.tetros.totalTetrominoes += 1;
            FindObjectOfType<StatBars>().UpdateBars();

            nextTetromino = tetrominoes[Random.Range(0, tetrominoes.Length)];
            if (nextImage != null)
            {
                Destroy(nextImage.gameObject);
            }
            nextImage = Instantiate(nextTetromino, transform.GetChild(0).position, transform.rotation, transform.GetChild(0));
            nextImage.GetComponent<Tetromino>().enabled = false;
        }
    }
}
