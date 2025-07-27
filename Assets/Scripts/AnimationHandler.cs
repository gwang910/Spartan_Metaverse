using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsFront = Animator.StringToHash("IsFront");
    private static readonly int IsBack = Animator.StringToHash("IsBack");
    private static readonly int IsLeft = Animator.StringToHash("IsLeft");
    private static readonly int IsRight = Animator.StringToHash("IsRight");

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void SetMoveDirection(Vector2 direction)
    {
        bool isMoving = direction.magnitude > 0.1f;

        if (!isMoving)
        {
            ResetDirectionBools();
            return;
        }

        direction.Normalize();

        ResetDirectionBools(); // ���� ��� bool�� false�� �ʱ�ȭ

        // ���� �Ǻ�
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
                animator.SetBool(IsRight, true);
            else
                animator.SetBool(IsLeft, true);
        }
        else
        {
            if (direction.y > 0)
                animator.SetBool(IsBack, true); // ������ ���� Back
            else
                animator.SetBool(IsFront, true); // �Ʒ����� ���� Front
        }
    }

    private void ResetDirectionBools()
    {
        animator.SetBool(IsFront, false);
        animator.SetBool(IsBack, false);
        animator.SetBool(IsLeft, false);
        animator.SetBool(IsRight, false);
    }
}
