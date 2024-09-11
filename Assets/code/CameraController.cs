using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class CameraController : MonoBehaviour
{

    [SerializeField] CinemachineFreeLook freeLook;

    private void Awake()
    {
        freeLook.Priority = 5;
    }

    private void LateUpdate()
    {
        FreeLook();
    }

    // ==============================================================================================================
    void FreeLook()
    {
        // ���콺 ��Ŭ�� ���� ��,
        if (Input.GetMouseButtonDown(1))
        {
            // Ŀ���� ����
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            freeLook.Priority = 20;
        }
        // ���콺 ��Ŭ�� �� ���� �� ��,
        else if (Input.GetMouseButtonUp(1))
        {
            // Ŀ���� �巯��
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            freeLook.Priority = 5;
        }
    }
}
