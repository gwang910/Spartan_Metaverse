using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform[] spawnTiles; // 동전이 생성될 위치
    public int totalCoins = 10;

    public Text scoreText;
    public Text timeText;
    public GameObject resultPanel;
    public Text resultTimeText;
    public Text bestTimeText;

    public GameObject noticePanel;

    private int collectedCoins = 0;
    private float timer = 0f;
    private bool isPlaying = false;
    private List<GameObject> activeCoins = new List<GameObject>();

    private float bestTime = float.MaxValue;

    void Update()
    {
        if (!isPlaying) return;

        timer += Time.deltaTime;
        timeText.text = timer.ToString("N2") + "s";
    }

    public void StartCoinGame()
    {
        StartCoroutine(ShowNoticeAndStart());
    }

    IEnumerator ShowNoticeAndStart()
    {
        noticePanel.SetActive(true);
        resultPanel.SetActive(false);
        timeText.gameObject.SetActive(false);

        yield return new WaitForSeconds(3f);

        noticePanel.SetActive(false);
        timeText.gameObject.SetActive(true);

        collectedCoins = 0;
        timer = 0f;
        isPlaying = true;

        scoreText.text = "0 / " + totalCoins;

        SpawnCoins();
    }

    void SpawnCoins()
    {
        // 기존 동전 제거
        foreach (var c in activeCoins)
            Destroy(c);

        activeCoins.Clear();

        if (spawnTiles.Length < totalCoins)
        {
            Debug.LogError("spawnTiles 개수가 totalCoins보다 적습니다. 무한 루프 방지!");
            totalCoins = spawnTiles.Length;  // 또는 return;
        }

        // 랜덤 위치 선택
        List<int> indices = new List<int>();
        while (indices.Count < totalCoins)
        {
            int rand = Random.Range(0, spawnTiles.Length);
            if (!indices.Contains(rand)) indices.Add(rand);
        }

        foreach (int i in indices)
        {
            GameObject coin = Instantiate(coinPrefab, spawnTiles[i].position, Quaternion.identity);
            activeCoins.Add(coin);
        }
    }

    public void CollectCoin(GameObject coin)
    {
        collectedCoins++;
        scoreText.text = collectedCoins + " / " + totalCoins;

        activeCoins.Remove(coin);
        Destroy(coin);

        if (collectedCoins >= totalCoins)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isPlaying = false;

        resultPanel.SetActive(true);
        resultTimeText.text = "Clear Time: " + timer.ToString("N2") + "s";

        if (timer < bestTime)
        {
            bestTime = timer;
        }

        bestTimeText.text = "Best Time: " + bestTime.ToString("N2") + "s";
    }
}
