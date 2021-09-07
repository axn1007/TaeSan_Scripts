using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public Transform centralAxis;
    public Transform cam;
    public float camSpeed;
    public float wheelSpeed;
    float mouseX;
    float mouseY;
    float wheel;
    float up;

    void CamMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.Space)) up = 1;
        else if (Input.GetKey(KeyCode.LeftShift)) up = -1;
        else up = 0;

        Vector3 dir = new Vector3(h, up, v);
        dir.Normalize();

        dir = Camera.main.transform.TransformDirection(dir);

        centralAxis.transform.position += dir * camSpeed * Time.deltaTime;

        if (Input.GetMouseButton(1))
        {
            mouseX += Input.GetAxis("Mouse X");
            mouseY += Input.GetAxis("Mouse Y") * -1;

            centralAxis.rotation = Quaternion.Euler(
                new Vector3(
                    centralAxis.rotation.x + mouseY,
                    centralAxis.rotation.y + mouseX,
                    0) * camSpeed);
        }
    }
    void Zoom()
    {
        wheel += Input.GetAxis("Mouse ScrollWheel") * wheelSpeed;
        if (wheel >= -10) wheel = -10;
        if (wheel <= -20) wheel = -20;
        cam.localPosition = new Vector3(0, 0, wheel);
    }

    void Update()
    {
        CamMove();
        Zoom();
    }
}
