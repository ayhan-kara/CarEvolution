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

    public float carAge;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (!gameManager.isStarted)
            return;
        Controller();
    }

    public void Controller()
    {
        
        moveVec3 += transform.forward * speed * Time.deltaTime;
        transform.position += moveVec3 * Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            mouseStart = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * steerAngle * Time.deltaTime * moveVec3.magnitude);
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
            if (transform.position.x > 1f && delta > 0)
            {
                return;
            }
            else if (transform.position.x < -1f && delta < 0)
            {
                return;
            }
        }
        moveVec3 *= dragAmount;
        moveVec3 = Vector3.ClampMagnitude(moveVec3, maxSpeed);
        moveVec3 = Vector3.Lerp(moveVec3.normalized, transform.forward, traction * Time.deltaTime) * moveVec3.magnitude;

        if (carAge > 10)
        {
            transform.GetChild(6).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.SetActive(false);

        }
        if (carAge < 10)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(5).gameObject.SetActive(true);
            transform.GetChild(6).gameObject.SetActive(false);
        }
    }

}
