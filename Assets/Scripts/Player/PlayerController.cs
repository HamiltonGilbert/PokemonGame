using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] BattleSystem battleSystem;

    public Transform view;

    public float moveSpeed;
    public LayerMask solidObjectLayer;
    public LayerMask grassLayer;

    public bool isMoving;
    private Vector2 input;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isMoving && !battleSystem.InBattle)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //remove diagonal movement
            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                var viewTargetPos = view.position;
                targetPos.x += input.x;
                targetPos.y += input.y;
                viewTargetPos.x += input.x;
                viewTargetPos.y += input.y;

                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos, viewTargetPos));
            }
        }

        animator.SetBool("isMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPos, Vector3 viewTargetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            view.position = Vector3.MoveTowards(view.position, viewTargetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        view.position = viewTargetPos;

        isMoving = false;

        CheckForEncounter();
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectLayer) != null)
        {
            return false;
        }
        return true;
    }

    private void CheckForEncounter()
    {
        if (Physics2D.OverlapCircle(transform.position, .2f, grassLayer) != null)
        {
            if (Random.Range(1, 101) <= 10)
            {
                battleSystem.SetupBattle();
            }
        }
    }
}
