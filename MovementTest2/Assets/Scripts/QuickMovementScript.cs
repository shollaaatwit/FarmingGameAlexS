using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMovementScript : MonoBehaviour
{
    Vector2 movement;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

 //           transform.Translate(movement.x*0.03f, movement.y*0.03f, 0);
    }
    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
       // rb.MovePosition(this.transform.position);
       rb.MovePosition(new Vector2((transform.position.x + movement.x * Time.deltaTime),(transform.position.y + movement.y * Time.deltaTime)));
    }
}
