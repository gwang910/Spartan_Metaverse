using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonVisibilityTrigger : MonoBehaviour
{
    [SerializeField] private GameObject buttonObject; // ¹öÆ°
    public Button button;

    private void Awake()
    {
        if (buttonObject != null)
        {
            button = buttonObject.GetComponent<Button>();
            HideButton();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShowButton();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HideButton();
        }
    }

    private void ShowButton()
    {
        buttonObject.SetActive(true);
        button.interactable = true;
    }

    private void HideButton()
    {
        button.interactable = false;
        buttonObject.SetActive(false);
    }
}
