using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobScript : EntityScript
{
    public Collider2D mobCollider;
    public PlayerScript player;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 20;
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mobCollider.IsTouching(player.weaponCollider))
        {
            health -= 5;
            StartCoroutine(Wait(1));
        }
        if (health <= 0)
            enabled = false;
    }

    IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
