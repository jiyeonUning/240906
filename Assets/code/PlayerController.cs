using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 플레이어 상태의 변경을 원활하게 하기 위한 열거형 선언
    enum State { Walk, Stop }

    // PlayerModel에서 설정한 값을 가져오기 위한 참조
    [SerializeField] PlayerModel model;
    // Rigidbody를 통한 움직임을 구현하기 위한 참조
    [SerializeField] Rigidbody rigid;
    // 값에 따라 애니메이션을 재생하기 위한 참조
    [SerializeField] Animator animator;

    // 현재 상태를 판단하기 위한 열거형
    [SerializeField] State curstate;
    // 조준 모드 활성화 여부
    bool gunMod; 
    

    private void Awake()
    {
        // 시작 시 플레이어의 상태를 Walk으로 설정한다.
        curstate = State.Walk;  
        // 시작 시 플레이어는 조준 모드를 사용하고 있지 않는다.
        gunMod = false;

        // 애니메이터에 있는 파라미터를 가져오기 위한 코드
        animator = GetComponent<Animator>();
        // 리기드바디를 통한 이동을 구현하기 위한 코드 
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // 현재 플레이어가 Stop 상태라면, 해당 상태를 유지한다.
        if (curstate == State.Stop) return;
        // 현재 플레이어의 상태가 Walk이라면, 플레이어의 움직임을 구현한 함수 Move를 실행한다.
        if (curstate == State.Walk) { Move(); }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (z > 0) Run(); // 상하이동값이 0보다 높다면, Run 함수를 실행

        Vector3 dir = new Vector3(x, 0, z);
        if (dir != Vector3.zero) { transform.forward = dir; }

        rigid.MovePosition(rigid.position + dir * model.MoveSpeed * Time.deltaTime);
        animator.SetFloat("MoveSpeed", z * model.MoveSpeed); // 애니메이션 속도를 플레이어 이동속도값으로 변경
        transform.Rotate(Vector3.up * x * model.RotateSpeed * Time.deltaTime, Space.World);
    }

    void Run()
    {
        if (gunMod) return;
        // 앞 방향키 두 번 눌렀을 때, 현재 움직임값을 RunSpeed에서 설정한 값으로 변경한다.
        // 달리기를 시작해 이동속도를 높인다
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            model.MoveSpeed = model.RunSpeed;
        }
        // 앞 방향키에서 손을 뗐을 때, 현재 움직임 값을 WalkSpeed에서 설정한 값으로 변경한다
        // = 달리기를 멈춰서 원래의 이동속도로 돌아온다
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
