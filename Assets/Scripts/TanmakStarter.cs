using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanmakStarter : MonoBehaviour
{
    public GameObject TanmakManager;  // ź�� �Ŵ��� ��Ȱ��ȭ ���·� ����
    public HeartUI heartUI;
    public int initialLife = 3;

    public void StartTanmakGame()
    {
        TanmakManager.SetActive(true);
        heartUI.ShowHearts(initialLife);  // ��Ʈ ���̰� �ϱ�
    }
}
