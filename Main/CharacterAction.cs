using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAction : MonoBehaviour
{
    public GameObject Hand;
    public GameObject Sword;
    
    private bool isAttacking = false;

    void Start()
    {
            
    }
    // Update is called once per frame
    void Update()
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
        /*
        Quaternion quaternion = new Quaternion();


        if (Input.GetMouseButton(0))
        {
            Sword.SetActive(true);
            Hand.transform.rotation = quaternion;
          //  Sword.SetActive(false);
        }
        */

        if (Input.GetMouseButton(0) && !isAttacking)
        {
            isAttacking = true;
        }

        if (isAttacking)
        {

            //Hand.transform.Rotate(new Vector3(0, 0, -15));
            Hand.transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation, 20f);

            Debug.Log(transform.rotation.eulerAngles.z);
           if (Hand.transform.rotation.eulerAngles.z > transform.rotation.eulerAngles.z+90)
            {
                Debug.Log("ddd");
                Hand.transform.rotation = Quaternion.Euler(0, 0, 90);
                //Hand.transform.Rotate(0, 0, 90);
                isAttacking = false;
            }
        }

         //   Hand.transform.rotation
    }

    public void Move()
    {
        float xMove = Input.GetAxisRaw("Horizontal") *CharacterManager.Get_instance().Ch_Speed * Time.deltaTime;
        float yMove = Input.GetAxisRaw("Vertical") * CharacterManager.Get_instance().Ch_Speed * Time.deltaTime;
        transform.position+=new Vector3(xMove,yMove);
        Hand.transform.position = transform.position;
        
       Vector2 mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;

        transform.up = mpos;

    }
}
