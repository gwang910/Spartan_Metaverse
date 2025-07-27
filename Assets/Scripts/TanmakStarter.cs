using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanmakStarter : MonoBehaviour
{
    public GameObject TanmakManager;  // 탄막 매니저 비활성화 상태로 시작
    public HeartUI heartUI;
    public int initialLife = 3;

    public void StartTanmakGame()
    {
        TanmakManager.SetActive(true);
        heartUI.ShowHearts(initialLife);  // 하트 보이게 하기
    }
}
