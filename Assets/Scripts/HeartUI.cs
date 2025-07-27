using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeartUI : MonoBehaviour
{
    public GameObject[] hearts;

    void Awake()
    {
        foreach (GameObject heart in hearts)
        {
            heart.SetActive(false);
        }
    }

    public void ShowHearts(int life)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < life);
        }
    }

    public void UpdateHearts(int life)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < life);
        }
    }

    public void HideAllHearts()
    {
        foreach (GameObject heart in hearts)
        {
            heart.SetActive(false);
        }
    }
}
