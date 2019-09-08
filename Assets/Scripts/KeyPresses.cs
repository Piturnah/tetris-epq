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
        if (GameManager.horizontalAxis == -1)
        {
            keys[2].color = Color.grey;
        } else if (GameManager.horizontalAxis == 1)
        {
            keys[4].color = Color.grey;
        } else
        {
            keys[2].color = Color.white;
            keys[4].color = Color.white;
        }


        if (GameManager.verticalInput == -1)
        {
            keys[3].color = Color.grey;
        }
        else
        {
            keys[3].color = Color.white;
        }

        if (GameManager.rotationAxis == 1)
        {
            keys[1].color = Color.grey;
        } else if (GameManager.rotationAxis == -1)
        {
            keys[0].color = Color.grey;
        } else
        {
            keys[0].color = Color.white;
            keys[1].color = Color.white;
        }
    }
}
