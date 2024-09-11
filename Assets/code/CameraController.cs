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
        // 마우스 우클릭 유지 시,
        if (Input.GetMouseButtonDown(1))
        {
            // 커서를 숨김
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            freeLook.Priority = 20;
        }
        // 마우스 우클릭 에 손을 뗄 시,
        else if (Input.GetMouseButtonUp(1))
        {
            // 커서를 드러냄
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            freeLook.Priority = 5;
        }
    }
}
