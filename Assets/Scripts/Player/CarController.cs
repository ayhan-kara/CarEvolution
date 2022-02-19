using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float dragAmount = 0.98f;

    Vector3 moveVec3;



    public float carAge;
    GameManager gameManager;
    Rigidbody rb;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!gameManager.isStarted)
            return;
        Controller();
    }

    public void Controller()
    {
        //moveVec3 += transform.forward * speed * Time.deltaTime;
        //transform.position += moveVec3 * Time.deltaTime;
        //transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * steerAngle * Time.deltaTime * moveVec3.magnitude);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    mouseStart = Input.mousePosition.x;
        //}
        //else if (Input.GetMouseButton(0))
        //{
        //    

        //    float delta = Input.mousePosition.x - mouseStart;
        //    mouseStart = Input.mousePosition.x;
        //    if (Mathf.Abs(delta) <= deadZone)
        //    {
        //        delta = 0;
        //    }
        //    else
        //    {
        //        delta = Mathf.Sign(delta);
        //    }
        //    if (transform.position.x > 7.4f && delta > 0)
        //    {
        //        return;
        //    }
        //    else if (transform.position.x < -7.4f && delta < 0)
        //    {
        //        return;
        //    }
        //    movementDelta += Vector3.right * horizontalSpeed * delta;
        //}
        //moveVec3 *= dragAmount;
        //moveVec3 = Vector3.ClampMagnitude(moveVec3, maxSpeed);
        //moveVec3 = Vector3.Lerp(moveVec3.normalized, transform.forward, traction * Time.deltaTime) * moveVec3.magnitude;

        //if (carAge > 10)
        //{
        //    transform.GetChild(6).gameObject.SetActive(true);

        //}
        //if (carAge < 10)
        //{
        //    transform.GetChild(0).gameObject.SetActive(true);
        //}
    }

}
