using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 2;
    public float moveSensitivityX = 10;
    public float moveSensitivityY = 10;

    private CharacterController pawn;
    private Camera cam;

    float cameraPitch = 0;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pawn = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        MovePlayer();
        TurnPlayer();
    }

    void TurnPlayer()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        transform.Rotate(0, h * moveSensitivityX, 0);

        cameraPitch += v * moveSensitivityY;
        cameraPitch = Mathf.Clamp(cameraPitch, -80, 80);

        cam.transform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);

    }

    void MovePlayer()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 speed = (transform.right * h + transform.forward * v) * moveSpeed;

        pawn.SimpleMove(speed);
    }
}
