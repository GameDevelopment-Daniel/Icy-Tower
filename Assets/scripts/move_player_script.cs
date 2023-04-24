using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class move_player_script : MonoBehaviour
{
    [SerializeField] int jumpforce;
    [SerializeField] int speed;

    [SerializeField]
    InputAction left = new InputAction(type: InputActionType.Button);
    [SerializeField]
    InputAction right = new InputAction(type: InputActionType.Button);

    Rigidbody2D rb;
    bool onGround;
    bool wantToJump;
    bool isJumped;

    public void OnEnable()
    {
        left.Enable();
        right.Enable();
    }

    public void OnDisable()
    {
        left.Disable();
        right.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        onGround = false;
        wantToJump = false;
        isJumped = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            onGround = true;
        }
        if (collision.gameObject.name == "destroyFloors")
        {
            GetComponent<move_player_script>().enabled = false;
            GameObject.Find("over").GetComponent<TextMeshProUGUI>().enabled = true;
            GameObject.Find("lvl2").GetComponent<TextMeshProUGUI>().text = "lvl 2\n score: " + GameObject.Find("points").GetComponent<TextMeshProUGUI>().text;
            GameObject.Find("points").GetComponent<TextMeshProUGUI>().enabled = false;


        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            onGround = false;
            wantToJump= false;
            isJumped = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround && Input.GetKeyDown(KeyCode.Space)) { wantToJump= true; }
    }
    private void FixedUpdate()
    {
        if (onGround && wantToJump && !isJumped)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            isJumped= true;
        }
        if (left.IsPressed())
        {
            transform.position += new Vector3(Time.deltaTime * speed * -1, 0, 0);
        }
        if (right.IsPressed())
        {
            transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
        }
    }

}
