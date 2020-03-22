﻿using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 1f;

    private void Update()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) direction += Vector3.up;
        if (Input.GetKey(KeyCode.A)) direction += Vector3.left;
        if (Input.GetKey(KeyCode.S)) direction += Vector3.down;
        if (Input.GetKey(KeyCode.D)) direction += Vector3.right;

        transform.Translate(direction.normalized * Time.deltaTime * speed);
    }
}
