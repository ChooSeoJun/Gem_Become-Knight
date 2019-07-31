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
		Sword.SetActive(false);
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

	bool canAttack = true;
    void Attack()
    {
		if (canAttack && Input.GetMouseButtonDown(0))
		{
			canAttack = false;
			StartCoroutine(attack());
		}
		//else if(canAttack) Hand.transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z); 
	}

	IEnumerator attack()
	{
		Sword.SetActive(true);
		for (int i = 1; i <= 12; i++)
		{
			//Hand.transform.rotation += Quaternion.Euler(0, 0, 1);// new Vector3(0, 0, i);
			Hand.transform.eulerAngles += new Vector3(0, 0, 15);
			yield return new WaitForSeconds(0.005f);
		}
		yield return new WaitForSeconds(0.05f);
		Hand.transform.eulerAngles += new Vector3(0, 0, -180);
		Sword.SetActive(false);
		canAttack = true;
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
