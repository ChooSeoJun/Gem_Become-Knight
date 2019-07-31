using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		PLAYER.x = transform.position.x;
		PLAYER.y = transform.position.y;
	}
}

public static class PLAYER
{
	public static float x;
	public static float y;
}