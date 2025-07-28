using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinStarter : MonoBehaviour
{
    public GameObject coinManager;

    public void StartGame()
    {
        // coinManager���� CoinManager ������Ʈ�� ������
        coinManager.SetActive(true);
        CoinManager manager = coinManager.GetComponent<CoinManager>();
        if (manager != null)
        {
            manager.StartCoinGame();
        }
        else
        {
            Debug.LogError("CoinManager ������Ʈ�� ã�� �� �����ϴ�.");
        }
    }
}

