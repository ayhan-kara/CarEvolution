using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float horizontalSpeed;
    private float deadZone = 0.1f;
    float mouseStart;
    Vector3 movDelta;
    Rigidbody rb;
    public Camera cam;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Controller();
        Move();
    }

    void Move()
    {
        rb.MovePosition(rb.position + movDelta * Time.smoothDeltaTime);
    }
    void Controller()
    {
        movDelta = Vector3.forward * speed;
        if (Input.GetMouseButtonDown(0))
        {
            mouseStart = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            float delta = Input.mousePosition.x - mouseStart;
            mouseStart = Input.mousePosition.x;
            if (Mathf.Abs(delta) <= deadZone)
            {
                delta = 0;
            }
            else
            {
                delta = Mathf.Sign(delta);
            }
            if (transform.position.x > 7.4f && delta > 0)
            {
                return;
            }
            else if (transform.position.x < -7.4f && delta < 0)
            {
                return;
            }
            movDelta += Vector3.right * horizontalSpeed * delta;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Road")
        {
            other.gameObject.transform.Rotate(0, -15, 0);
            cam.transform.Rotate(0, -15, 0);
        }
    }

}
