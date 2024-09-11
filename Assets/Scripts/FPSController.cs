using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform camTransform;
    [SerializeField] float camRotateSpeed;

    [SerializeField] int damage;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, 0, z);
        if (moveDir.sqrMagnitude > 1)
        {
            moveDir.Normalize();
        }

        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }

    private void Look()
    {
        float x = Input.GetAxisRaw("Mouse X");
        float y = Input.GetAxisRaw("Mouse Y");

        transform.Rotate(Vector3.up, x * camRotateSpeed * Time.deltaTime);
        camTransform.Rotate(Vector3.right, -y * camRotateSpeed * Time.deltaTime);
    }
}
