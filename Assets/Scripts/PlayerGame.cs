using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGame : MonoBehaviour
{
    public int playerHealth = 100;
    public CharacterController controller;

    Vector3 movement;
    Vector3 mouseLook;
    Vector3 mouseLookhead;
    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public float mouseSensitivity = 100f;

    public Transform playerHead;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerHead = GetComponentInChildren<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        mouseLook= new Vector3(0,Input.GetAxis("Mouse X"), 0);
        mouseLookhead = new Vector3(Input.GetAxis("Mouse Y"),0,0);

        transform.Rotate(mouseLook*mouseSensitivity*Time.smoothDeltaTime);

        playerHead.Rotate(-mouseLookhead.x*mouseSensitivity*Time.smoothDeltaTime,0,0,Space.Self);

       
        if (controller.isGrounded && movement.y < 0)
        {
            movement.y = 0f;
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            movement.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        movement.y += gravity * Time.deltaTime *10;

        controller.Move(movement * moveSpeed * Time.deltaTime);
        
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movement = transform.right * x + transform.forward * z;
    }
}
