using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �÷��̾� ������ ������ ��Ȱ�ϰ� �ϱ� ���� ������ ����
    enum State { Walk, Stop }

    // PlayerModel���� ������ ���� �������� ���� ����
    [SerializeField] PlayerModel model;
    // Rigidbody�� ���� �������� �����ϱ� ���� ����
    [SerializeField] Rigidbody rigid;
    // ���� ���� �ִϸ��̼��� ����ϱ� ���� ����
    [SerializeField] Animator animator;

    // ���� ���¸� �Ǵ��ϱ� ���� ������
    [SerializeField] State curstate;
    // ���� ��� Ȱ��ȭ ����
    bool gunMod; 
    

    private void Awake()
    {
        // ���� �� �÷��̾��� ���¸� Walk���� �����Ѵ�.
        curstate = State.Walk;  
        // ���� �� �÷��̾�� ���� ��带 ����ϰ� ���� �ʴ´�.
        gunMod = false;

        // �ִϸ����Ϳ� �ִ� �Ķ���͸� �������� ���� �ڵ�
        animator = GetComponent<Animator>();
        // �����ٵ� ���� �̵��� �����ϱ� ���� �ڵ� 
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // ���� �÷��̾ Stop ���¶��, �ش� ���¸� �����Ѵ�.
        if (curstate == State.Stop) return;
        // ���� �÷��̾��� ���°� Walk�̶��, �÷��̾��� �������� ������ �Լ� Move�� �����Ѵ�.
        if (curstate == State.Walk) { Move(); }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (z > 0) Run(); // �����̵����� 0���� ���ٸ�, Run �Լ��� ����

        Vector3 dir = new Vector3(x, 0, z);
        if (dir != Vector3.zero) { transform.forward = dir; }

        rigid.MovePosition(rigid.position + dir * model.MoveSpeed * Time.deltaTime);
        animator.SetFloat("MoveSpeed", z * model.MoveSpeed); // �ִϸ��̼� �ӵ��� �÷��̾� �̵��ӵ������� ����
        transform.Rotate(Vector3.up * x * model.RotateSpeed * Time.deltaTime, Space.World);
    }

    void Run()
    {
        if (gunMod) return;
        // �� ����Ű �� �� ������ ��, ���� �����Ӱ��� RunSpeed���� ������ ������ �����Ѵ�.
        // �޸��⸦ ������ �̵��ӵ��� ���δ�
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            model.MoveSpeed = model.RunSpeed;
        }
        // �� ����Ű���� ���� ���� ��, ���� ������ ���� WalkSpeed���� ������ ������ �����Ѵ�
        // = �޸��⸦ ���缭 ������ �̵��ӵ��� ���ƿ´�
        else if (Input.GetKeyUp(KeyCode.LeftShift)) { model.MoveSpeed = model.WalkSpeed; }
    }

    public void CheckGunMod()
    {
        gunMod = !gunMod;
        if (gunMod) { model.MoveSpeed = model.AimSpeed; }
        else { model.MoveSpeed = model.WalkSpeed; }
    }

    void StopMove()
    {
        animator.SetFloat("MoveSpeed", 0);
        model.MoveSpeed = model.WalkSpeed;
    }

    public void Interact()
    {
        curstate = State.Stop;
        StopMove();
    }

    public void UnInteract()
    {
        curstate = State.Walk;
    }
}
