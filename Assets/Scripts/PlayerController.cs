using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]  
    public float moveSpeed;  
    private Vector2 curMovementInput;  
    public float jumpPower;
    public LayerMask groundLayerMask;

    [Header("Look")]    
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot; 
    public float lookSensitivity; 

    private Vector2 mouseDelta;

    [HideInInspector]
    public bool canLook = true;

    private Rigidbody _rigidbody;  

    public Camera maincamera;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();  
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        if (canLook)
        {
            CameraLook();
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)  
    {
        if (context.phase == InputActionPhase.Performed) 
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnLookInput(InputAction.CallbackContext context)  
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse); 
        }
    }

    private void Move()  //ĳ���� ���� �̵�
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x; 
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y; 

        _rigidbody.velocity = dir; 
    }

    void CameraLook() 
    {
        camCurXRot += mouseDelta.y * lookSensitivity;  
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook); 
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0); 

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0); 
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) +(transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }
}