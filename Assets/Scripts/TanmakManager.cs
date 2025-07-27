using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanmakManager : MonoBehaviour
{
    public GameObject tanmakPrefab;
    public Transform[] spawnPoints;
    public float spawnRate = 0.2f;

    private float timer;
    private bool isRunning = false;

    void OnEnable()
    {
        isRunning = true;
        timer = 0;
    }

    void Update()
    {
        if (!isRunning) return;

        timer += Time.deltaTime;
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
            GameObject bullet = Instantiate(tanmakPrefab, point.position, Quaternion.identity);

            // 360도 중 랜덤한 각도 생성
            float angle = Random.Range(0f, 360f);
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

            bullet.GetComponent<TanmakBall>().Init(direction);
        }
    }
}
