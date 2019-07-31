using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GEM
{


	public static float gemX;
	public static float gemY;
	public static bool mons;

}


public class gemPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		GEM.mons = false;
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log("잼의 상태" + GEM.mons);
		if (!GEM.mons)
		{
			GEM.gemX = transform.position.x;
			GEM.gemY = transform.position.y;
			//gameObject.SetActive(true);
		}
		else
		{
			gameObject.SetActive(false);
		}
    }
}

