using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanmakBall : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;

    public float speed = 3f;
    private Vector2 moveDirection;

    public void Init(Vector2 direction)
    {
        moveDirection = direction.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            Destroy(gameObject);
    }



    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

}
