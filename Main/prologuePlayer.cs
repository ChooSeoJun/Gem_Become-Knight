using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class prologuePlayer : MonoBehaviour
{
	public GameObject space;
	public Text say;
	public Image black;

    // Start is called before the first frame update
    void Start()
    {
		space.SetActive(false);
		say.text = "";
		black.color = new Color(0, 0, 0, 0);
	}


	string[] saying = { "너는 나에게 선택 되었다", "왕국으로 떠나도록 해라" };
	float a = 0.5f;
	bool b = true;
    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
		{
			if(transform.position.x <= a)
				transform.Translate(new Vector2(3 * Time.deltaTime, 0));
		}
		if (b)
		{
			if (transform.position.x >= a)
			{
				//text띄우기
				space.SetActive(true);
				if (Input.GetKeyDown(KeyCode.Space))
				{
					b = false;
					space.SetActive(false); //text지우기
					//보석이 말걸기
					StartCoroutine(saygem());
				}
			}
		}

    }

	IEnumerator saygem()
	{
		int i;
		for (i = 0; i <= 13; i++)
		{
			say.text = saying[0].Substring(0, i);
			yield return new WaitForSeconds(0.1f);
		}
		say.text = "";
		for (i = 0; i <= saying[1].Length; i++)
		{
			say.text = saying[1].Substring(0, i);
			yield return new WaitForSeconds(0.1f);
		}
		yield return new WaitForSeconds(1f);
		for (i = 0; i <= 255; i+=5)
		{
			black.color = new Color(0, 0, 0, (float)i / 255);
			yield return new WaitForSeconds(0.02f);
		}
	}

}
