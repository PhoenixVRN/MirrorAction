using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTplayer : MonoBehaviour
{
     public float distanceBlink;
    [Space]
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 11.5f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

//    private CharacterController _characterController;
    Vector3 moveDirection = Vector3.zero;
    private float _rotationX = 0;

    [HideInInspector] public bool canMove = true;
    [HideInInspector] public bool hit;
    
    void Start()
    {
//        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
 //       if (!isLocalPlayer) playerCamera.gameObject.SetActive(false);
    }

   
    void Update()
    {
        MovePlayer();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<Target>().Hit();
        Debug.Log(other.contactCount.ToString());
    }

    public void Hit()
    {
        
    }

    private void MovePlayer()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
         
        /*
        if (Input.GetButton("Jump") && canMove && _characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            // хня какая то
         //   moveDirection.y = moveDirectionY;
        }*/
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Блинк");
            moveDirection = (forward * distanceBlink);
        }
        
        /*if (!_characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        _characterController.Move(moveDirection * Time.deltaTime);*/
        
        if (canMove)
        {
            _rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            _rotationX = Mathf.Clamp(_rotationX, lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
   
}
