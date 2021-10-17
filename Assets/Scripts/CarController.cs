using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody2D carRigidbody;
    public Rigidbody2D backTire;
    public Rigidbody2D frontTire;

    public float movementPower;
    public float carTorgue;
    public float speed;
    private float movement;
    public float rotatePower;
    public float minDisToGround;


    // Update is called once per frame
    void Update()
    {
        movement = 0;
        if (Input.GetKey(KeyCode.Space))
        {
            movement = movementPower;
        }
    }

    private bool isGrounded()
    {
        Vector3 start;
        start.x = transform.position.x-0.2f;
        start.y = transform.position.y+0.5f;
        start.z = transform.position.z;

        Vector2 direction = new Vector2(transform.position.x,
            transform.position.y-1000);

        RaycastHit2D hit = Physics2D.Raycast(start, direction);
        Debug.DrawRay(start, direction, Color.red);
        float distance = 0;
        if (hit.collider != null)
        {
            distance = Mathf.Abs(hit.point.y - transform.position.y);
            
        }
        if (distance < minDisToGround)
        {
            //Debug.Log("2");
            return true;
        }
        else
        {
            //Debug.Log("3");
            return false;
        }
        
    }

    private void FixedUpdate()
    {
        
        if (isGrounded())
        {
            backTire.AddTorque(-movement * speed * Time.fixedDeltaTime);
            frontTire.AddTorque(-movement * speed * Time.fixedDeltaTime);
            carRigidbody.AddTorque(-movement * carTorgue * Time.fixedDeltaTime); 
   
        }
        else
        {
            Debug.Log("Obr");
            backTire.AddTorque(-movement * speed *20* Time.fixedDeltaTime);
            frontTire.AddTorque(-movement * speed *20* Time.fixedDeltaTime);
            carRigidbody.AddTorque(-movement * carTorgue*20 * Time.fixedDeltaTime);

            if (movement > 0)
            {
                //Debug.Log("Obracanie");
                //Vector3 rotationChange = new Vector3(0, 0,rotatePower);
                //transform.RotateAround(transform.position, Vector3.forward, rotatePower);
            }
            
        }
    }
}
