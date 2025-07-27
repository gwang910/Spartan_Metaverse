using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;

    public HeartUI heartUI;
    private int currentHP = 3;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tanmak"))
        {
            currentHP--;
            heartUI.UpdateHearts(currentHP);

            if (currentHP <= 0)
            {
                Debug.Log("Game Over");
                // TODO: 게임 종료 처리
                currentHP += 3;
            }

            Destroy(collision.gameObject);
        }
    }
}
