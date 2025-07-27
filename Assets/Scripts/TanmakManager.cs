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
        timeTxt.gameObject.SetActive(true); // �ؽ�Ʈ ������Ʈ Ȱ��ȭ
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

        // ���� ź�� ����
        foreach (var obj in GameObject.FindGameObjectsWithTag("Tanmak"))
        {
            Destroy(obj);
        }

        // �ð� ����
        currentTimeText.text = $"{elapsedTime:0.00}";

        if (elapsedTime > bestTime)
        {
            bestTime = elapsedTime;
        }
        bestTimeText.text = $"{bestTime:0.00}";

        // �г� ǥ��
        gameOverPanel.SetActive(true);
    }

    public void EndGame()
    {
        gameOverPanel.SetActive(false);  // �г� �ݱ�
        gameObject.SetActive(false);     // ź�� ���� ��ü ��Ȱ��ȭ
        timeTxt.gameObject.SetActive(false); // Ÿ�̸� ǥ�� ��Ȱ��ȭ
    }
}
