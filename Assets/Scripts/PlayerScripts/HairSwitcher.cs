using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairSwitcher : MonoBehaviour
{
    public GameObject[] hairStyles;

    public void SwitchHair(int dir)
    {
        switch (dir)
        {
            case 0:
                hairStyles[0].SetActive(true);
                hairStyles[1].SetActive(false);
                hairStyles[2].SetActive(false);
                hairStyles[3].SetActive(false);
                break;
            case 1:
                hairStyles[0].SetActive(false);
                hairStyles[1].SetActive(true);
                hairStyles[2].SetActive(false);
                hairStyles[3].SetActive(false);
                break;
            case 2:
                hairStyles[0].SetActive(false);
                hairStyles[1].SetActive(false);
                hairStyles[2].SetActive(true);
                hairStyles[3].SetActive(false);
                break;
            case 3:
                hairStyles[0].SetActive(false);
                hairStyles[1].SetActive(false);
                hairStyles[2].SetActive(false);
                hairStyles[3].SetActive(true);
                break;
            default:
                break;
        }
    }
}
