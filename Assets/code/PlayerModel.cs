using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    // �ִϸ��̼� ������ ���� �ڵ� : �ڷ�ƾ
    // �ִϸ��̼� �Ķ���� - �÷��̾� ������ ���� ����� �𸣰ھ ��� �л� �ڵ� ����:����ִ� �ڵ带 �Ű����� �Ǿ����ϴ�.
    // ������ ������ ��������ν� cs���� ��� �������� ���� ������ �������� ���� �ϱ� ���ؼ�

    [Header("Player Move Status")]
    //===============================================================================
    //                               �⺻ �̵��ӵ� �� ����
    // �������� ���� �����ϰ� �ִ� moveSpeed�� �ְ�, MoveSpeed�� get set �ڵ带 ���Ͽ�
    // MoveSpeed ��� �� ��µǴ� ���� moveSpeed�� ������ش�.
    // ����, moveSpeed�� ���� value�� �����Ͽ� �ִϸ��̼� �Ķ���� ���� ���������� �� �ִ�.
    [SerializeField] float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    //===============================================================================
    //                         �ɾ�ٴ� ���� �̵��ӵ� �� ����
    [SerializeField] float walkSpeed;
    public float WalkSpeed { get { return walkSpeed; } set { walkSpeed = value; } }
    //===============================================================================
    //                         �پ�ٴ� ���� �̵��ӵ� �� ����
    [SerializeField] float runSpeed;
    public float RunSpeed { get { return runSpeed; } set { runSpeed = value; } }
    //===============================================================================
    //                               ȸ���ӵ� �� ����
    [SerializeField] float rotateSpeed;
    public float RotateSpeed { get {return rotateSpeed; } set { rotateSpeed = value; } }
    //===============================================================================
    //                  ���ظ�忡 �������� ���� �̵��ӵ� �� ���� 
    [SerializeField] float aimSpeed;
    public float AimSpeed { get {return aimSpeed; } set { aimSpeed = value; } }
}
