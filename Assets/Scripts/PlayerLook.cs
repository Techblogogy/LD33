using UnityEngine;
using System.Collections.Generic;

public class PlayerLook:MonoBehaviour
{
    Vector2 _mouseAbsolute;
    Vector2 _smoothMouse;

    public Vector2 clamp = new Vector2(360, 180);
    public bool lockCursor;
    public Vector2 sensitivity = new Vector2(2, 2);
    public Vector2 smoothing = new Vector2(3, 3);
    public Vector2 targetDir;
    public Vector2 targetCharDir;

    public GameObject charBody;

    void Start()
    {
        targetDir = transform.localRotation.eulerAngles;

        if (charBody) targetCharDir = charBody.transform.localRotation.eulerAngles;
    }

    void Update()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        var targetOrient = Quaternion.Euler(targetDir);
        var targetCharOrient = Quaternion.Euler(targetCharDir);

        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));

        _smoothMouse.x = Mathf.Lerp(_smoothMouse.x, mouseDelta.x, 1.0f / smoothing.x);
        _smoothMouse.y = Mathf.Lerp(_smoothMouse.y, mouseDelta.y, 1.0f / smoothing.y);

        _mouseAbsolute += _smoothMouse;

        if (clamp.x < 360)
        {
            _mouseAbsolute.x = Mathf.Clamp(_mouseAbsolute.x, -clamp.x * 0.5f, clamp.x * 0.5f);
        }

        var xRot = Quaternion.AngleAxis(-_mouseAbsolute.y, targetOrient * Vector3.right);
        transform.localRotation = xRot;

        if (clamp.y < 360)
        {
            _mouseAbsolute.y = Mathf.Clamp(_mouseAbsolute.y, -clamp.y * 0.5f, clamp.y * 0.5f);
        }

        transform.localRotation *= targetOrient;

        if (charBody) 
        {
            var yRot = Quaternion.AngleAxis(_mouseAbsolute.x, charBody.transform.up);
            charBody.transform.localRotation = yRot;
            charBody.transform.localRotation *= targetCharOrient;
        }
        else
        {
            var yRot = Quaternion.AngleAxis(_mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));
            transform.localRotation *= yRot;
        }
    }
}
