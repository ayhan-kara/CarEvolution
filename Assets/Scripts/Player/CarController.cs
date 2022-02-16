using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;
    [SerializeField] float steerAngle;
    [SerializeField] float traction;

    float dragAmount = 0.98f;
    float mouseStart;
    float deadZone = 0.1f;
    Vector3 moveVec3;

    private void Update()
    {
        Controller();
        Movement();
    }

    public void Controller()
    {
        moveVec3 += transform.forward * speed * Time.deltaTime;
        transform.position += moveVec3 * Time.deltaTime;
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * steerAngle * Time.deltaTime * moveVec3.magnitude);


        moveVec3 *= dragAmount;
        moveVec3 = Vector3.ClampMagnitude(moveVec3, maxSpeed);
        moveVec3 = Vector3.Lerp(moveVec3.normalized, transform.forward, traction * Time.deltaTime) * moveVec3.magnitude;
    }

    public void Movement()
    {
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
        }
    }
}
