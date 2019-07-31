using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterActions : MonoBehaviour
{
	float[,] posDoor = {{-30f, 0f}, {30f, 0f}, {0f, 23f}, {0f, -23f}};
	float moveSpeed = 3.0f;
	int door;
	public GameObject gem;

	bool moveDoor;

	// Start is called before the first frame update
	void Start()
    {
		gem = GameObject.Find("g_gem");
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


    // Update is called once per frame
    void Update()
    {
		if((transform.position.x >= posDoor[door, 0]-1 && transform.position.x <= posDoor[door, 0] + 1) && (transform.position.y >= posDoor[door, 1] - 1 && transform.position.y <= posDoor[door, 1] + 1)) moveDoor = false;
		if (moveDoor)
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(posDoor[door, 0], posDoor[door, 1], 0), moveSpeed * Time.deltaTime);
		else
		{
			if (Wall.breakCount[door] > 0)
			{
				StartCoroutine(AttackWall());
			}
			else
			{
				if(Vector2.Distance(transform.position, new Vector2(PLAYER.x, PLAYER.y)) <= 9)
				{
					transform.position = Vector3.MoveTowards(transform.position, new Vector2(PLAYER.x,PLAYER.y), moveSpeed * Time.deltaTime);
				}
				else
					transform.position = Vector3.MoveTowards(transform.position, new Vector2(GEM.gemX, GEM.gemY), moveSpeed * Time.deltaTime);
			}
		}
	}

	IEnumerator Attack()
	{
		//애니메이션
		//플레이어 체력 깎기
		yield return new WaitForSeconds(1.0f);
	}
	IEnumerator AttackWall()
	{
		Wall.breakCount[door]--;
		//애니메이션
		yield return new WaitForSeconds(1.0f);
	}
}
