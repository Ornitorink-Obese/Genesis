using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : EntityScript
{
    public Rigidbody2D body;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            body.position += Vector2.up * (speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            body.position += Vector2.down * (speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            body.position += Vector2.left * (speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            body.position += Vector2.right * (speed * Time.deltaTime);
    }
}
