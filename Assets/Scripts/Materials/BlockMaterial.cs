using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMaterial : MonoBehaviour
{
    [SerializeField] Material[] palletJS;
    [SerializeField] Material[] palletZL;

    void Update()
    {
        palletJS[10].SetColor("_Color", palletJS[ScoreManager.level % 10].color);
        palletZL[10].SetColor("_Color", palletZL[ScoreManager.level % 10].color);
    }
}
