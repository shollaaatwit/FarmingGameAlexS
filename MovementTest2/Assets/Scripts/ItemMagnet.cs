using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMagnet : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float forceAmount;

    private void Update()
    {
        transform.position = player.transform.position;
    }

    public void GravitateItem(GameObject gObject)
    {
        rb = gObject.GetComponent<Rigidbody2D>();
        rb.AddForce((gameObject.transform.position - gObject.transform.position) * forceAmount * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Item")
        {
            GravitateItem(collider.gameObject);
        }
    }
}
