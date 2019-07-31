using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAction : MonoBehaviour
{

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

    public void Move()
    {
        float xMove = Input.GetAxisRaw("Horizontal") *CharacterManager.Get_instance().Ch_Speed * Time.deltaTime;
        float yMove = Input.GetAxisRaw("Vertical") * CharacterManager.Get_instance().Ch_Speed * Time.deltaTime;
        transform.position+=new Vector3(xMove,yMove);

        Vector2 mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;

        transform.up = mpos;

    }
}
