using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 2;
    public float mouseSensitivityX = 10;
    public float mouseSensitivityY = 10;

    private CharacterController pawn;
    private Camera cam;

    float cameraPitch = 0;

    void Start()
    {
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

        transform.Rotate(0, h * mouseSensitivityX, 0);

        //cam.transform.Rotate(v * mouseSensitivityY, 0, 0);

        cameraPitch += v * mouseSensitivityY;

        //if (cameraPitch < -80) cameraPitch = -80;
        //if (cameraPitch > 80) cameraPitch = 80;

        cameraPitch = Mathf.Clamp(cameraPitch, -80, 80);

        cam.transform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);

    }

    void MovePlayer()
    {
        // get input:

        float v = Input.GetAxis("Vertical"); // W + S / UP + DOWN arrows : a value between -1 and 1
        float h = Input.GetAxis("Horizontal"); // A + D / LEFT + RIGHT arrows : a value between -1 and 1

        //transform.position += new Vector3(moveSpeed * Time.deltaTime * h, 0, 0);
        //transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime * v);

        //transform.position += transform.right * moveSpeed * Time.deltaTime * h;
        //transform.position += transform.forward * moveSpeed * Time.deltaTime * v;

        //transform.position += (transform.right * h + transform.forward * v) * moveSpeed * Time.deltaTime;

        Vector3 speed = (transform.right * h + transform.forward * v) * moveSpeed; // We don't use deltaTime because

        pawn.SimpleMove(speed); // simple move adds gravity for us! (if you want jump and more, you should not use simple move then and use Move)
    }
}
