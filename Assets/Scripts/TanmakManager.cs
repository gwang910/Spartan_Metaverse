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
            FireBullet();
        }
    }

    void FireBullet()
    {
        foreach (var point in spawnPoints)
        {
            Instantiate(tanmakPrefab, point.position, Quaternion.identity);
        }
    }
}
