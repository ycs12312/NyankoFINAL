using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{

    Vector3 MoveRight;
    Vector3 MoveLeft;

    public float CameraSpeed;
    public Camera MainCamera;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        CameraSpeed = 8.0f;

        MoveRight = transform.position;
        MoveRight.x = 2.4f;

        MoveLeft = transform.position;
        MoveLeft.x = -2.4f;
    }

    private void Update()
    {
        if (transform.position.x > 2.4)
            transform.position = MoveRight;
        if (transform.position.x < -2.4)
            transform.position = MoveLeft;

        if (Input.GetKey(KeyCode.LeftArrow))
            MainCamera.transform.position += Vector3.left * CameraSpeed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.RightArrow))
            MainCamera.transform.position += Vector3.right * CameraSpeed * Time.deltaTime;
    }


}
