using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 1f;

    private float xValue, yValue = 0f, zValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            // Movement of the player through Input.GetKey
            //MovementThroughGetKey();

            // Movement of the player through Input.GetAxis
            MovementThroughGetAxis();
        }
    }

    private void MovementThroughGetKey()
    {
        Vector3 movement = Vector3.zero;

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            movement += Vector3.left * moveSpeed;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            movement += Vector3.right * moveSpeed;
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            movement += Vector3.forward * moveSpeed;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            movement += Vector3.back * moveSpeed;
        }

        transform.Translate(movement * Time.deltaTime);
    }

    private void MovementThroughGetAxis()
    {
        xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(xValue, yValue, zValue);
    }
}
