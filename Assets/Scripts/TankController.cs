using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    [SerializeField] float aimRotateSpeed;
    [SerializeField] float maxAimRotate;

    private float yAimAngle;
    private float xAimAngle;

    private void Update()
    {
        Move();
        Aim();
    }

    private void Move()
    {
        float x = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            x += 1;
        }

        float z = 0;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            z -= 1;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            z += 1;
        }

        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, x * rotateSpeed * Time.deltaTime);
    }

    private void Aim()
    {
        float y = 0;
        if (Input.GetKey(KeyCode.A))
        {
            y -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            y += 1;
        }

        float x = 0;
        if (Input.GetKey(KeyCode.S))
        {
            x -= 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            x += 1;
        }

        yAimAngle = Mathf.Clamp(yAimAngle + y * aimRotateSpeed * Time.deltaTime, -maxAimRotate, maxAimRotate);
        xAimAngle = Mathf.Clamp(xAimAngle - x * aimRotateSpeed * Time.deltaTime, -maxAimRotate, 0);
    }
}
