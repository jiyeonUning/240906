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

    // ���� �� �÷��̾��� �⺻ ���·� Walk �Լ� ����
    private void Awake() { Walk(); }

    private void Update()
    {
        // ���콺 ��Ŭ�� ���� ��, ���� ��� ����
        if (Input.GetMouseButtonDown(0)) { gunMod(); }
        // ������ ��Ŭ�� ���� ��, ���� ��� ����
        if (Input.GetMouseButtonUp(0)) { Walk(); }
        animator.SetBool("GunMod", IsGunMod);
    }

    void gunMod()
    {
        // �ִϸ����Ϳ��� GunMod�� true ��ȯ
        IsGunMod = true;
        gun.SetActive(true);
        // ����Ƽ�̺�Ʈ �Լ� ����
        OngunMod.Invoke();
    }

    void Walk()
    {
        // �ִϸ����Ϳ��� GunMod�� false ��ȯ
        IsGunMod = false;
        gun.SetActive(false);
        // ����Ƽ�̺�Ʈ �Լ� ����
        OngunMod?.Invoke();
    }
}
