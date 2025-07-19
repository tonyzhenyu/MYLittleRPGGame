using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public abstract class BtnGenerator : MonoBehaviour
{
    public GameObject origin;
    public Transform content;
    public string ResourcesPath;
    public void Start()
    {
        GenerateBtns();
    }
    public abstract void GenerateBtns();
    public void ClearBtns()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("Btn"))
        {
            Destroy(item);
        }
    }
}
