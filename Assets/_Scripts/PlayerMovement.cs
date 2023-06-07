using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private float movementSpeed = 100f;

    private Quaternion tempRotationValue = Quaternion.identity;
    private Rigidbody rb;
    private float playerIdealPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerIdealPosition = gameObject.GetComponent<Transform>().position.y;
    }

    private void Update()
    {
        // Horizontal axis only controls rotation
        if(Input.GetAxis("Horizontal") != 0)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);
        }
        // vertical axis only controls the velocity 
        if(Input.GetAxis("Vertical") != 0)
        {
            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(0, 0, verticalInput * movementSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        tempRotationValue = gameObject.transform.rotation;
        tempRotationValue.x = 0;
        tempRotationValue.z = 0;
    }

    private void OnCollisionExit(Collision collision)
    {
        //rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.rotation = tempRotationValue;
        
        this.gameObject.transform.position =
            new Vector3(this.gameObject.transform.position.x, playerIdealPosition, this.gameObject.transform.position.z);

    }
}
