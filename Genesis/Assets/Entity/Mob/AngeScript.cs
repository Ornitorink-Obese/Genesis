using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngeScript : MobScript
{
    // Start is called before the first frame update
    void Start()
    {
        health = 20;
        damage = 5;
        speed = 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (havetarget)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position , speed * Time.deltaTime);
        }

        if(target.IsTouching(mobCollider) )
        {
            StartCoroutine(Waitfor());
        }

        if (Input.GetKeyDown(KeyCode.K))
            health = 0;
        if (health <= 0)
        {
            Destroy(transform.gameObject);
        }
    }
}
