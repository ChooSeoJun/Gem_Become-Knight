using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterActions : MonoBehaviour
{
	float[,] posDoor = {{-30f, 0f}, {30f, 0f}, {0f, 23f}, {0f, -23f}};
	float moveSpeed = 3.0f;
	int door;
    int MonHp = 10;
	bool moveDoor;

	// Start is called before the first frame update
	void Start()
    {
		moveDoor = true;
		float distance = (transform.position.x - posDoor[0,0]) * (transform.position.x - posDoor[0,0]) + (transform.position.y - posDoor[0,1]) * (transform.position.y - posDoor[0,1]);
		for (int i = 1; i < 4; i++)
		{
			if(distance > (transform.position.x - posDoor[i,0]) * (transform.position.x - posDoor[i,0]) + (transform.position.y - posDoor[i,1]) * (transform.position.y - posDoor[i,1]))
			{
				door = i;
				distance = (transform.position.x - posDoor[i,0]) * (transform.position.x - posDoor[i,0]) + (transform.position.y - posDoor[i,1]) * (transform.position.y - posDoor[i,1]);
			}
		}

		//float xPos, yPos;
		/*for(int i=0;i<100;i++)//while(transform.position.x != posDoor[door, 0] || transform.position.y != posDoor[door, 1])
		{
			if (transform.position.x > posDoor[door, 0]) xPos = -1;
			else if (transform.position.x < posDoor[door, 0]) xPos = 1;
			else xPos = 0;

			if (transform.position.y > posDoor[door, 1]) yPos = -1;
			else if (transform.position.y < posDoor[door, 1]) yPos = 1;
			else yPos = 0;

			xPos *= Time.deltaTime * moveSpeed;
			yPos *= Time.deltaTime* moveSpeed;

			transform.Translate(new Vector2(xPos, yPos));
		}*/
        
		


	}

    bool co = true;
	bool getGem = false;
	int goDoor;
    // Update is called once per frame
    void Update()
    {
		if((transform.position.x >= posDoor[door, 0]-1 && transform.position.x <= posDoor[door, 0] + 1) && (transform.position.y >= posDoor[door, 1] - 1 && transform.position.y <= posDoor[door, 1] + 1)) moveDoor = false;
		if (moveDoor)
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(posDoor[door, 0], posDoor[door, 1], 0), moveSpeed * Time.deltaTime);
		else
		{
            if (co)
            {
				if (Wall.breakCount[door] > 0)
				{
					StartCoroutine(AttackWall());
				}
				else
				{
					if (!getGem)
					{
						if ((Vector2.Distance(transform.position, new Vector2(PLAYER.x, PLAYER.y)) <= 9 &&
							Vector2.Distance(transform.position, new Vector2(PLAYER.x, PLAYER.y)) <= Vector2.Distance(transform.position, new Vector2(GEM.gemX, GEM.gemY)))
							|| GEM.mons == true)
						{
							transform.position = Vector3.MoveTowards(transform.position, new Vector2(PLAYER.x, PLAYER.y), moveSpeed * Time.deltaTime);
						}
						else
							transform.position = Vector3.MoveTowards(transform.position, new Vector2(GEM.gemX, GEM.gemY), moveSpeed * Time.deltaTime);

					}
					else
					{
						goDoor = whatDoor();
						transform.position = Vector3.MoveTowards(transform.position, new Vector3(posDoor[goDoor, 0], posDoor[goDoor, 1], 0), moveSpeed * Time.deltaTime);
						if(Math.Abs((int)transform.position.x) >= 28 || Math.Abs((int)transform.position.y) >= 21)
						{
							//gameover
							Debug.Log("game over");
						}
					}
				}
            }
		}
	}
   
    int whatDoor()
	{
		int result=0;
		float distance = (transform.position.x - posDoor[0, 0]) * (transform.position.x - posDoor[0, 0]) + (transform.position.y - posDoor[0, 1]) * (transform.position.y - posDoor[0, 1]);
		if (Wall.breakCount[0] > 0) distance = 9999.0f;
		for (int i = 1; i < 4; i++)
		{
			if (Wall.breakCount[i] > 0) i++;
			if (distance > (transform.position.x - posDoor[i, 0]) * (transform.position.x - posDoor[i, 0]) + (transform.position.y - posDoor[i, 1]) * (transform.position.y - posDoor[i, 1]))
			{
				result = i;
				distance = (transform.position.x - posDoor[i, 0]) * (transform.position.x - posDoor[i, 0]) + (transform.position.y - posDoor[i, 1]) * (transform.position.y - posDoor[i, 1]);
			}
		}
		return result;
	}

	IEnumerator AttackWall()
	{
        co = false;

		Wall.breakCount[door]--;
		//애니메이션
		yield return new WaitForSeconds(1.0f);

        co = true;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.transform.tag == "Player")
        {
            CharacterManager.Get_instance().Ch_Hp -= 1;
            Debug.Log("플레이어 아프다");
            Debug.Log(CharacterManager.Get_instance().Ch_Hp);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Sword")
        {
            Debug.Log("몬스터 아프다");
            Debug.Log(MonHp);
            MonHp -= CharacterManager.Get_instance().Ch_Power;
            if(MonHp < 0)
            {
				if (getGem)
				{
					GEM.mons = false;
					//이펙트off
				}
				Destroy(gameObject);
                CharacterManager.Get_instance().liveMon -=1;
                Debug.Log(CharacterManager.Get_instance().liveMon);
            }
        }

		if(collision.transform.tag == "gem")
		{
			GEM.mons = true;
			getGem = true;
			//이펙트on
			//collision.transform.position = transform.position;
		}
    }
}
