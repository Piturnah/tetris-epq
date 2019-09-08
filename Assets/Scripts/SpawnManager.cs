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
        Instantiate(nextTetromino, transform.position, transform.rotation, transform);
        nextTetromino = tetrominoes[Random.Range(0, tetrominoes.Length)];
        if (nextImage != null)
        {
            Destroy(nextImage.gameObject);
        }
        nextImage = Instantiate(nextTetromino, transform.GetChild(0).position, transform.rotation, transform.GetChild(0));
        nextImage.GetComponent<Tetromino>().enabled = false;
    }
}
