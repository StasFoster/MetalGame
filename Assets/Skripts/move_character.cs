using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class move_character : MonoBehaviour
{
    public GameObject player_;
    CharacterController pla;
    public Camera pl;
    Vector3 move_des;
    float x_pos, z_pos, y_mouse, x_mouse, y_mouse_curent, x_mouse_curent, y_mouse_velosity, x_mouse_velosity, smoothTime;
    float sen = 0.5f;
    float sen_mouse = 2f;
    private void Start()
    {
        pla = GetComponent<CharacterController>();
    }
    void Update()
    {
        moveing();
        Move();
    }
    public void Move()
    {
        x_pos = Input.GetAxis("Horizontal") * sen;
        z_pos = Input.GetAxis("Vertical") * sen;
        move_des = new Vector3(x_pos, 0f, z_pos);
        move_des = transform.TransformDirection(move_des);
        pla.Move(move_des);
    }
    public void moveing()
    {
        y_mouse += Input.GetAxis("Mouse X") * sen_mouse;
        x_mouse += Input.GetAxis("Mouse Y") * sen_mouse;
        y_mouse_curent = Mathf.SmoothDamp(y_mouse_curent, y_mouse, ref y_mouse_velosity, smoothTime);
        x_mouse_curent = Mathf.SmoothDamp(x_mouse_curent, x_mouse, ref x_mouse_velosity, smoothTime);
        pl.transform.rotation = Quaternion.Euler(-x_mouse_curent, y_mouse_curent, 0f);
        player_.transform.rotation = Quaternion.Euler(0f, y_mouse, 0f);
    }
}
