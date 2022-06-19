using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _mouseX;
    private float _mouseY;

    [Header("Чувствительность мыши")]
    public float sensitivityMouse = 200f;

    public Transform player;
    void Start()
    {
//        Cursor.lockState = CursorLockMode.Locked;
//        Cursor.visible = false;
    }

    
    void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * sensitivityMouse * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * sensitivityMouse * Time.deltaTime;

        player.Rotate(_mouseX * new Vector3(0, 1, 0));
        
        transform.Rotate(-_mouseY * new Vector3(1, 0, 0));
    }
}
