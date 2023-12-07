using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forTransparentObje : MonoBehaviour
{
    public GameObject[] transparanObjem;

    public void olustur(int index)
    {
        Instantiate(transparanObjem[index]);
    }
}
