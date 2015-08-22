using UnityEngine;
using System.Collections.Generic;

public class PlayerController:MonoBehaviour
{
    public float velocity = 9.0F;
    public float gravity = 10.0F;

    private CharacterController charCtr; //Character Controller
    private Vector3 charDir;

    void Start()
    {
        charCtr = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (charCtr.isGrounded)
        {
            charDir = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
            charDir = transform.TransformDirection(charDir);
            charDir *= velocity;
        }

        charDir.y -= Time.deltaTime * gravity;
        charCtr.Move(charDir * Time.deltaTime);
    }
}