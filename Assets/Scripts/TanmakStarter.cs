using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanmakStarter : MonoBehaviour
{
    public GameObject TanmakManager;  // ź�� �Ŵ��� ��Ȱ��ȭ ���·� ����

    public void StartTanmakGame()
    {
        TanmakManager.SetActive(true);
    }
}
