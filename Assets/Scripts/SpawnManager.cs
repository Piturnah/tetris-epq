using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] tetrominoes;
    public static GameObject nextTetromino;

    private void Start()
    {
        nextTetromino = tetrominoes[Random.Range(0, tetrominoes.Length)];
        SpawnTetromino();
    }
    public void SpawnTetromino()
    {
        Instantiate(nextTetromino, transform.position, transform.rotation, transform);
        nextTetromino = tetrominoes[Random.Range(0, tetrominoes.Length)];
    }
}
