using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMONSTER : MonoBehaviour
{
	public GameObject monster;
	int MonNum = 20;


	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(CreateMonster());
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	IEnumerator CreateMonster()
	{
		for(int i=0;i<MonNum;i++)
		{
			int x, y;
			do
			{
				x = Random.Range(-40, 41);
				y = Random.Range(-30, 30);
			}
			while ((x >= -27 && x <= 27) && (y >= -20 && y <= 20));


			Instantiate(monster, new Vector2(x, y), transform.rotation);
			yield return new WaitForSeconds(2.0f);
		}
		
	}
}
