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
        // 애니메이터에 있는 파라미터를 가져오기 위한 코드
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
