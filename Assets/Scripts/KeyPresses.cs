using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPresses : MonoBehaviour
{
    Image[] keys = new Image[5];

    private void Start()
    {
        foreach (Transform child in transform)
        {
            keys[child.GetSiblingIndex()] = child.GetComponent<Image>();
        }
    }
    private void Update()
    {
        //Change colour for left and right input
        if (GameManager.horizontalAxis == -1)
        {
            keys[2].color = Color.red;
        } else if (GameManager.horizontalAxis == 1)
        {
            keys[4].color = Color.red;
        } else
        {
            keys[2].color = Color.white;
            keys[4].color = Color.white;
        }

        //Change colour for down input
        if (GameManager.verticalInput == -1)
        {
            keys[3].color = Color.red;
        }
        else
        {
            keys[3].color = Color.white;
        }

        //Change colour for rotation input
        if (GameManager.rotationAxis == 1)
        {
            keys[1].color = Color.red;
        } else if (GameManager.rotationAxis == -1)
        {
            keys[0].color = Color.red;
        } else
        {
            keys[0].color = Color.white;
            keys[1].color = Color.white;
        }
    }
}
