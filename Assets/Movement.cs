using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 1f;
    [SerializeField] private Transform debugHitPointTransform;
    [SerializeField] private Transform hookshotTransform;

    private CharacterController characterController;
    private float cameraVerticalAngle;
    private float characterVelocityY;
    private Vector3 characterVelocityMomentum;
    private Camera playerCamera;
    private State state;
    private Vector3 hookshotPosition;
    private float hookshotSize;

    public bool mouseMove = true;

    private enum State
	{
        Normal,
        HookshotFlyingPlayer,
        HookshotThrown
	}

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = transform.Find("Camera").GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        state = State.Normal;
        hookshotTransform.gameObject.SetActive(false);
    }

    private void Update()
    {
        switch (state)
		{
            default:
            case State.Normal:
                HandleCharacterLook();
                HandleCharacterMovement();
                HandleHookshotStart();
                break;
            case State.HookshotThrown:
                HandleHookshotThrown();
                HandleCharacterLook();
                HandleCharacterMovement();
                break;
            case State.HookshotFlyingPlayer:
                HandleHookshotMovement();
                HandleCharacterLook();
                break;
        }
        
    }

    private void HandleCharacterLook()
    {
        if (mouseMove == true)
        {
            float lookX = Input.GetAxisRaw("Mouse X");
            float lookY = Input.GetAxisRaw("Mouse Y");

            transform.Rotate(new Vector3(0f, lookX * mouseSensitivity, 0f), Space.Self);
            cameraVerticalAngle -= lookY * mouseSensitivity;
            cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -90f, 90f);
            playerCamera.transform.localEulerAngles = new Vector3(cameraVerticalAngle, 0, 0);

        }
    }

    private void HandleCharacterMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        float moveSpeed = 10f;

        Vector3 characterVelocity = transform.right * moveX * moveSpeed + transform.forward * moveZ * moveSpeed;

        if (characterController.isGrounded)
        {
            characterVelocityY = 0f;
            if (TestInputJump())
            {
                float jumpSpeed = 10f;
                characterVelocityY = jumpSpeed;
            }
        }

        float gravityDownForce = -20f;
        characterVelocityY += gravityDownForce * Time.deltaTime;
        characterVelocity.y = characterVelocityY;
        characterVelocity += characterVelocityMomentum;
        characterController.Move(characterVelocity * Time.deltaTime);

        if(characterVelocityMomentum.magnitude >= 0f)
		{
            float momentumDrag = 3f;
            characterVelocityMomentum -= characterVelocityMomentum * momentumDrag * Time.deltaTime;

            if(characterVelocityMomentum.magnitude < .0f)
			{
                characterVelocityMomentum = Vector3.zero;
			}
		}
    }

    private void ResetGravityEffect()
	{
        characterVelocityY = 0f;
    }

    private void HandleHookshotStart()
	{
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit raycastHit))
            {
                if (raycastHit.transform.tag == "grapple")
				{
                    debugHitPointTransform.position = raycastHit.point;
                    hookshotPosition = raycastHit.point;
                    hookshotSize = 0f;
                    hookshotTransform.gameObject.SetActive(true);
                    hookshotTransform.localScale = Vector3.zero;
                    state = State.HookshotThrown;
                }
			}
		}
	}

    private void HandleHookshotThrown()
	{
        hookshotTransform.LookAt(hookshotPosition);

        float hookshotThrowSpeed = 70f;
        hookshotSize += hookshotThrowSpeed * Time.deltaTime;
        hookshotTransform.localScale = new Vector3(1, 1, hookshotSize);

        if (hookshotSize >= Vector3.Distance(transform.position, hookshotPosition))
		{
            state = State.HookshotFlyingPlayer;
		}
	}

    private void HandleHookshotMovement()
	{
        hookshotTransform.LookAt(hookshotPosition);

        Vector3 hookshotDir = (hookshotPosition - transform.position).normalized;

        float hookshotSpeed = 25f;
        characterController.Move(hookshotDir * hookshotSpeed * Time.deltaTime);

        float reachedHookshotPositionDistance = 1f;
        if (Vector3.Distance(transform.position, hookshotPosition) < reachedHookshotPositionDistance)
		{
            state = State.Normal;
            ResetGravityEffect();
            hookshotTransform.gameObject.SetActive(false);
        }

        if (TestInputJump())
		{
            float momentumExtraSpeed = 2.5f;
            characterVelocityMomentum = hookshotDir * hookshotSpeed * momentumExtraSpeed;
            float jumpSpeed = 20f;
            characterVelocityMomentum += Vector3.up * jumpSpeed;
            state = State.Normal;
            ResetGravityEffect();
            hookshotTransform.gameObject.SetActive(false);
        }
    }

    private bool TestInputJump()
	{
        return Input.GetKeyDown(KeyCode.Space);
    }
}
