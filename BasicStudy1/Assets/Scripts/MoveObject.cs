﻿using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 5.0f; //이동속도

    // Update is called once per frame
    void Update()
    {
        //키 입력에 따라 이동
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        //transform.Translate(Vector3.right * move * speed * Time.deltaTime);

        //transform.position += move * speed * Time.deltaTime;
        transform.Translate(move * speed * Time.deltaTime);
    }
}
