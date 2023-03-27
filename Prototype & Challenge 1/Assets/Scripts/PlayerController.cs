using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower = 5.0f;
    [SerializeField] private float turnSpeed = 5.0f;
    public float horizontalInput;
    public float verticaldInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI rmpText;
    [SerializeField] float rpm;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.localPosition;
    }

    void Update() 
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticaldInput = Input.GetAxis("Vertical");

        if(true)
        {
            //vehicle moves forward
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);   
            playerRb.AddRelativeForce(Vector3.forward * verticaldInput * horsePower);
            //vehicle turn left or right
            transform.Rotate(Vector3.up * turnSpeed * horizontalInput);

            speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
            rpm = Mathf.Round((speed%30)*40);

            speedText.text = "Speed: " + speed + "mph";
            rmpText.text = "RPM: " + rpm;
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;

        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
