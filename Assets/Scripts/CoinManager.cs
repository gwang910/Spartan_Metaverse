using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public GameObject coinPrefab;
    public Tilemap groundTilemap; // 동전이 생성될 타일맵
    public int coinCount = 10;

    public GameObject resultPanel;
    public Text resultTimeText;

    public Text scoreText;
    public Text timeText;

    private int score = 0;
    private float timer = 0f;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SpawnCoins();
        UpdateScoreText();
    }

    public void SpawnCoins()
    {
        BoundsInt bounds = groundTilemap.cellBounds;

        int attempts = 0;
        int spawned = 0;

        while (spawned < coinCount && attempts < 1000)
        {
            attempts++;

            int x = Random.Range(bounds.xMin, bounds.xMax);
            int y = Random.Range(bounds.yMin, bounds.yMax);
            Vector3Int cellPos = new Vector3Int(x, y, 0);

            // 해당 셀에 타일이 존재하는 경우만 동전 생성
            if (groundTilemap.HasTile(cellPos))
            {
                Vector3 worldPos = groundTilemap.CellToWorld(cellPos) + new Vector3(0.5f, 0.5f, 0); // 중앙 보정
                Instantiate(coinPrefab, worldPos, Quaternion.identity);
                spawned++;
            }
        }
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void ResetGame()
    {
        score = 0;
        UpdateScoreText();

        foreach (var coin in GameObject.FindGameObjectsWithTag("Coin"))
        {
            Destroy(coin);
        }

        SpawnCoins();
    }
}
