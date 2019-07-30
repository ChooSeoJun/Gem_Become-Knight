using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAction : MonoBehaviour
{
    public float Move_Speed = 10f;

    void Start()
    {
            
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Skill();
        Attack();
    }

    void Skill()
    {
          
    }

    void Attack()
    {
        
    }

    void Move()
    {
        float xMove = Input.GetAxisRaw("Horizontal") * Move_Speed * Time.deltaTime;
        float yMove = Input.GetAxisRaw("Vertical") * Move_Speed * Time.deltaTime;
        transform.position+=new Vector3(xMove,yMove);

        Vector2 mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;

        transform.up = mpos;
    }
}
