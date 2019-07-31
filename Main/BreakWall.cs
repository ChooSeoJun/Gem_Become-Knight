using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{
	public GameObject[] walls = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 4; i++)
		{
			if (Wall.breakCount[i] <= 0)
			{
				walls[i].SetActive(false);
			}
		}
    }
}

public static class Wall
{
	public static int[] breakCount = { 10, 10, 10, 10 };
}