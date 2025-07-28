using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Tilemap groundTilemap;          // ������ ������ Ÿ�ϸ� (Tilemap ������Ʈ)
    public GameObject coinPrefab;
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

    private List<Vector3> availablePositions = new List<Vector3>();

    void Start()
    {
        // Ÿ�ϸ� ���� ���� Ÿ���� �����ϴ� ��� �� ��ġ(���� ��ǥ) ����
        BoundsInt bounds = groundTilemap.cellBounds;
        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int cellPos = new Vector3Int(x, y, 0);
                if (groundTilemap.HasTile(cellPos))
                {
                    Vector3 worldPos = groundTilemap.CellToWorld(cellPos) + groundTilemap.tileAnchor;
                    availablePositions.Add(worldPos);
                }
            }
        }
    }

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
        // ���� ���� ����
        foreach (var c in activeCoins)
            Destroy(c);
        activeCoins.Clear();

        if (availablePositions.Count == 0)
        {
            Debug.LogError("Ÿ�ϸʿ��� ��ȿ�� Ÿ�� ��ġ�� �����ϴ�!");
            return;
        }

        List<int> usedIndices = new List<int>();

        int spawned = 0;
        int maxAttempts = 1000;
        int attempts = 0;

        while (spawned < totalCoins && attempts < maxAttempts)
        {
            attempts++;
            int index = Random.Range(0, availablePositions.Count);
            if (usedIndices.Contains(index)) continue; // �̹� ���� ��ġ�� �ǳʶ�

            Vector3 spawnPos = availablePositions[index];

            // ���� ����
            GameObject coin = Instantiate(coinPrefab, spawnPos, Quaternion.identity);
            activeCoins.Add(coin);

            usedIndices.Add(index);
            spawned++;
        }

        if (spawned < totalCoins)
        {
            Debug.LogWarning("�Ϻ� ������ �������� �ʾҽ��ϴ�. Ÿ�� ��ġ�� ������ �� �ֽ��ϴ�.");
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
        resultTimeText.text = timer.ToString("N2");

        if (timer < bestTime)
        {
            bestTime = timer;
        }

        bestTimeText.text = bestTime.ToString("N2");
    }

    public void EndGame()
    {
        resultPanel.SetActive(false);  // �г� �ݱ�
        gameObject.SetActive(false);     // ź�� ���� ��ü ��Ȱ��ȭ
        timeText.gameObject.SetActive(false); // Ÿ�̸� ǥ�� ��Ȱ��ȭ
    }
}
