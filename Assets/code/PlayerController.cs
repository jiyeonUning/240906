using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody rigid;
    private Animator animator;


    private void Awake()
    {
        // �ִϸ����Ϳ� �ִ� �Ķ���͸� �������� ���� �ڵ�
        animator = GetComponentInChildren<Animator>();
        rigid = gameObject.GetComponent<Rigidbody>();

        //moveSpeed = animator.GetFloat("moveSpeed");
    }

    void LateUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, 0, z);
        if (dir != Vector3.zero) { transform.forward = dir; }

        rigid.MovePosition(rigid.position + dir * moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(dir);
    }
}
