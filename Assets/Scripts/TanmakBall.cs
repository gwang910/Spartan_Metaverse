using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanmakBall : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer spriteRenderer;

    public float speed = 3f;
    private Vector2 moveDirection;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    public void Init(Vector2 direction)
    {
        moveDirection = direction.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (levelCollisionLayer.value == (levelCollisionLayer.value | (1 << collision.gameObject.layer)))
        {
            DestroyProjectile(collision.ClosestPoint(transform.position));
        }
    }



    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    // 투사체 파괴 함수
    private void DestroyProjectile(Vector3 position)
    {
        Destroy(this.gameObject);
    }

}
