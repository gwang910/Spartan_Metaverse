using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinStarter : MonoBehaviour
{
    public GameObject coinManager;

    public void StartGame()
    {
        // coinManager에서 CoinManager 컴포넌트를 가져옴
        coinManager.SetActive(true);
        CoinManager manager = coinManager.GetComponent<CoinManager>();
        if (manager != null)
        {
            manager.StartCoinGame();
        }
        else
        {
            Debug.LogError("CoinManager 컴포넌트를 찾을 수 없습니다.");
        }
    }
}

