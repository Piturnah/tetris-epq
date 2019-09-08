using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBars : MonoBehaviour
{
    Image[] bars = new Image[7];

    public void UpdateBars()
    {
        Debug.Log("updating bars");
        foreach (Image bar in bars)
        {
            float tetrominoCount = 0;
            switch (bar.transform.GetSiblingIndex())
            {
                case 0:
                    tetrominoCount = GameManager.tetros.tTetrominoes;
                    break;
                case 1:
                    tetrominoCount = GameManager.tetros.jTetrominoes;
                    break;
                case 2:
                    tetrominoCount = GameManager.tetros.zTetrominoes;
                    break;
                case 3:
                    tetrominoCount = GameManager.tetros.oTetrminoes;
                    break;
                case 4:
                    tetrominoCount = GameManager.tetros.sTetrominoes;
                    break;
                case 5:
                    tetrominoCount = GameManager.tetros.lTetrominoes;
                    break;
                case 6:
                    tetrominoCount = GameManager.tetros.iTetrominoes;
                    break;
            }
            bar.fillAmount = tetrominoCount / (float)GameManager.tetros.totalTetrominoes;
        }
    }
    private void Awake()
    {
        foreach (Transform child in transform)
        {
            bars[child.GetSiblingIndex()] = child.GetComponent<Image>();
        }
    }
}
