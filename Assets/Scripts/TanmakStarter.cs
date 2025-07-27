using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanmakStarter : MonoBehaviour
{
    public GameObject TanmakManager;  // 탄막 매니저 비활성화 상태로 시작
    public HeartUI heartUI;
    public GameObject noticePanel;

    public float noticeDuration = 3f;

    public int initialLife = 3;

    private float timer = 0f;
    private bool isNoticeRunning = false;

    public void StartTanmakGame()
    {
        noticePanel.SetActive(true);
        timer = 0f;
        isNoticeRunning = true;
    }

    void Update()
    {
        if (isNoticeRunning)
        {
            timer += Time.deltaTime;
            if (timer >= noticeDuration)
            {
                noticePanel.SetActive(false);
                TanmakManager.SetActive(true);
                heartUI.ShowHearts(initialLife);
                isNoticeRunning = false;
            }
        }
    }
}
