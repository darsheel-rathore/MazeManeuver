using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private bool isHit = false;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!isHit)
            {
                this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                // Increment the score
                collision.gameObject.GetComponent<ScoreManagement>().IncrementScore();
                // Make sure score increment will not work again for this object
                isHit = true;
            }
        }
    }

    // This Event will make sure that player hasn't have any velocity
    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
