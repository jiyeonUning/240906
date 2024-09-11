using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerGunMode : MonoBehaviour
{
    [SerializeField] PlayerModel model;
    [SerializeField] Animator animator;
    [SerializeField] GameObject gun;

    [SerializeField] bool IsGunMod;
    public UnityEvent OngunMod;

    // 시작 시 플레이어의 기본 상태로 Walk 함수 실행
    private void Awake() { Walk(); }

    private void Update()
    {
        // 마우스 좌클릭 유지 시, 조준 모드 실행
        if (Input.GetMouseButtonDown(0)) { gunMod(); }
        // 마우즈 좌클릭 해제 시, 조준 모드 해제
        if (Input.GetMouseButtonUp(0)) { Walk(); }
        animator.SetBool("GunMod", IsGunMod);
    }

    void gunMod()
    {
        // 애니메이터에서 GunMod를 true 전환
        IsGunMod = true;
        gun.SetActive(true);
        // 유니티이벤트 함수 실행
        OngunMod.Invoke();
    }

    void Walk()
    {
        // 애니메이터에서 GunMod를 false 전환
        IsGunMod = false;
        gun.SetActive(false);
        // 유니티이벤트 함수 실행
        OngunMod?.Invoke();
    }
}
