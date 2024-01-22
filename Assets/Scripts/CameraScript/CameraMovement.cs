using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    [Space, SerializeField]
    Vector2 movement;

    [Space, SerializeField]
    Vector2 maxRadius;
    [SerializeField]
    Vector2 minRadius;

    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = movement * speed;
        //rb2d.AddForce(movement * speed);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minRadius.x, maxRadius.x), Mathf.Clamp(transform.position.y, minRadius.y, maxRadius.y));
    }

    public void Movement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}
