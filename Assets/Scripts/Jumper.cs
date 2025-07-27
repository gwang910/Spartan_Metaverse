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
                // �ö󰡴� ��
                offsetY = Mathf.Lerp(0f, jumpHeight, progress * 2f);
            }
            else if (progress < 1f)
            {
                // �������� ��
                offsetY = Mathf.Lerp(jumpHeight, 0f, (progress - 0.5f) * 2f);
            }
            else
            {
                // ���� ��
                isJumping = false;
                offsetY = 0f;
            }

            // ���� �̵��� �����ϰ�, y���� offset �߰�
            Vector3 currentPos = transform.position;
            currentPos.y = originalY + offsetY;
            transform.position = currentPos;
        }
    }
}

