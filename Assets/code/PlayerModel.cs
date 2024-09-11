using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    // 애니메이션 실행을 위한 코드 : 코루틴
    // 애니메이션 파라미터 - 플레이어 움직임 연동 방법을 모르겠어서 우수 학생 코드 예제:노승주님 코드를 옮겨적게 되었습니다.
    // 정보를 가져와 사용함으로써 cs파일 어느 곳에서든 같은 정보를 가져오게 쉽게 하기 위해서

    [Header("Player Move Status")]
    //===============================================================================
    //                               기본 이동속도 값 설정
    // 실질적인 값을 저장하고 있는 moveSpeed가 있고, MoveSpeed에 get set 코드를 통하여
    // MoveSpeed 사용 시 출력되는 값은 moveSpeed로 만들어준다.
    // 또한, moveSpeed의 값은 value로 설정하여 애니메이션 파라미터 값과 연동시켜줄 수 있다.
    [SerializeField] float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    //===============================================================================
    //                         걸어다닐 때의 이동속도 값 설정
    [SerializeField] float walkSpeed;
    public float WalkSpeed { get { return walkSpeed; } set { walkSpeed = value; } }
    //===============================================================================
    //                         뛰어다닐 때의 이동속도 값 설정
    [SerializeField] float runSpeed;
    public float RunSpeed { get { return runSpeed; } set { runSpeed = value; } }
    //===============================================================================
    //                               회전속도 값 설정
    [SerializeField] float rotateSpeed;
    public float RotateSpeed { get {return rotateSpeed; } set { rotateSpeed = value; } }
    //===============================================================================
    //                  조준모드에 돌입했을 때의 이동속도 값 설정 
    [SerializeField] float aimSpeed;
    public float AimSpeed { get {return aimSpeed; } set { aimSpeed = value; } }
}
