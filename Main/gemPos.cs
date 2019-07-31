using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GEM
{


	public static float gemX;
	public static float gemY;

}


public class gemPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		GEM.gemX = transform.position.x;
		GEM.gemY = transform.position.y;
    }
}

