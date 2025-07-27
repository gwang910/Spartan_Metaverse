using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float jumpHeight = 0.4f;
    [SerializeField] private float jumpDuration = 1f;

    private bool isJumping = false;
    private float jumpTimer = 0f;
    private float originalY = 0f;

    void Update()
    {
        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            originalY = transform.position.y;
            isJumping = true;
            jumpTimer = 0f;
        }

        if (isJumping)
        {
            jumpTimer += Time.deltaTime;
            float progress = jumpTimer / jumpDuration;

            float offsetY = 0f;

            if (progress < 0.5f)
            {
                // 올라가는 중
                offsetY = Mathf.Lerp(0f, jumpHeight, progress * 2f);
            }
            else if (progress < 1f)
            {
                // 내려오는 중
                offsetY = Mathf.Lerp(jumpHeight, 0f, (progress - 0.5f) * 2f);
            }
            else
            {
                // 점프 끝
                isJumping = false;
                offsetY = 0f;
            }

            // 현재 이동은 유지하고, y에만 offset 추가
            Vector3 currentPos = transform.position;
            currentPos.y = originalY + offsetY;
            transform.position = currentPos;
        }
    }
}

