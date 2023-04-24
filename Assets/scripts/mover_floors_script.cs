using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class mover_floors_script : MonoBehaviour
{
    
    [SerializeField] float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.transform.SetParent(this.transform);
        }
        if(collision.gameObject.name == "destroyFloors")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.transform.SetParent(null);
        }
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);

    }
}
