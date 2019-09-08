using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMaterial : MonoBehaviour
{
    [SerializeField] Material[] palletJS;
    [SerializeField] Material[] palletZL;

    void Update()
    {
        switch (ScoreManager.level)
        {
            case 0:
                palletJS[0].SetColor("_Color", palletJS[0].color);
                palletZL[0].SetColor("_Color", palletZL[0].color);
                break;
            case 1:
                palletJS[0].SetColor("_Color", palletJS[1].color);
                palletZL[0].SetColor("_Color", palletZL[1].color);
                break;
            case 2:
                palletJS[0].SetColor("_Color", palletJS[2].color);
                palletZL[0].SetColor("_Color", palletZL[2].color);
                break;
            case 3:
                palletJS[0].SetColor("_Color", palletJS[3].color);
                palletZL[0].SetColor("_Color", palletZL[3].color);
                break;
            case 4:
                palletJS[0].SetColor("_Color", palletJS[4].color);
                palletZL[0].SetColor("_Color", palletZL[4].color);
                break;
            case 5:
                palletJS[0].SetColor("_Color", palletJS[5].color);
                palletZL[0].SetColor("_Color", palletZL[5].color);
                break;
            case 6:
                palletJS[0].SetColor("_Color", palletJS[6].color);
                palletZL[0].SetColor("_Color", palletZL[6].color);
                break;
            case 7:
                palletJS[0].SetColor("_Color", palletJS[7].color);
                palletZL[0].SetColor("_Color", palletZL[7].color);
                break;
            case 8:
                palletJS[0].SetColor("_Color", palletJS[8].color);
                palletZL[0].SetColor("_Color", palletZL[8].color);
                break;
            case 9:
                palletJS[0].SetColor("_Color", palletJS[9].color);
                palletZL[0].SetColor("_Color", palletZL[9].color);
                break;
            case 10:
            case 11:
            case 12:
                palletJS[0].SetColor("_Color", palletJS[10].color);
                palletZL[0].SetColor("_Color", palletZL[10].color);
                break;
            case 13:
            case 14:
            case 15:
                palletJS[0].SetColor("_Color", palletJS[1].color);
                palletZL[0].SetColor("_Color", palletZL[1].color);
                break;
            case 16:
            case 17:
            case 18:
                palletJS[0].SetColor("_Color", palletJS[2].color);
                palletZL[0].SetColor("_Color", palletZL[2].color);
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
                palletJS[0].SetColor("_Color", palletJS[3].color);
                palletZL[0].SetColor("_Color", palletZL[3].color);
                break;
            default:
                palletJS[0].SetColor("_Color", palletJS[9].color);
                palletZL[0].SetColor("_Color", palletZL[9].color);
                break;
        }
    }
}
