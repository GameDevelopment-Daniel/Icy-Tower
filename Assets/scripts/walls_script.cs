using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walls_script : MonoBehaviour
{
    // Start is called before the first frame update
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
            Debug.Log("was in parentsss");
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.transform.SetParent(null);
        }
    }
}
