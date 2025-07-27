using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanmakBall : MonoBehaviour
{
    public float speed = 3f;
    private Vector2 moveDirection;

    public void Init(Vector2 direction)
    {
        moveDirection = direction.normalized;
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� �ε����� ����
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
