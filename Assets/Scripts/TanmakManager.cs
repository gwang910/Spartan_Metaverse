using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TanmakManager : MonoBehaviour
{
    public GameObject tanmakPrefab;
    public Transform[] spawnPoints;
    public float spawnRate = 0.2f;

    public Text timeTxt;
    private float timer;
    private float elapsedTime;
    private bool isRunning = false;

    public GameObject gameOverPanel;
    public Text currentTimeText;
    public Text bestTimeText;

    public int initialLife = 3;

    private float bestTime = 0f;

    void OnEnable()
    {
        timeTxt.gameObject.SetActive(true); // 텍스트 오브젝트 활성화
        isRunning = true;
        timer = 0;
        elapsedTime = 0;
    }

    void Update()
    {
        if (!isRunning) return;

        timer += Time.deltaTime;
        elapsedTime += Time.deltaTime;

        timeTxt.text = elapsedTime.ToString("N2");

        if (timer >= spawnRate)
        {
            timer = 0;
            FireTanmak();
        }
    }

    void FireTanmak()
    {
        foreach (var point in spawnPoints)
        {
            GameObject tanmak = Instantiate(tanmakPrefab, point.position, Quaternion.identity);

            float angle = Random.Range(0f, 360f);
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

            tanmak.GetComponent<TanmakBall>().Init(direction);
        }
    }

    public void GameOver()
    {
        isRunning = false;

        // 기존 탄막 제거
        foreach (var obj in GameObject.FindGameObjectsWithTag("Tanmak"))
        {
            Destroy(obj);
        }

        // 시간 갱신
        currentTimeText.text = $"{elapsedTime:0.00}";

        if (elapsedTime > bestTime)
        {
            bestTime = elapsedTime;
        }
        bestTimeText.text = $"{bestTime:0.00}";

        // 패널 표시
        gameOverPanel.SetActive(true);
    }

    public void EndGame()
    {
        gameOverPanel.SetActive(false);  // 패널 닫기
        gameObject.SetActive(false);     // 탄막 게임 전체 비활성화
        timeTxt.gameObject.SetActive(false); // 타이머 표시 비활성화
    }
}
