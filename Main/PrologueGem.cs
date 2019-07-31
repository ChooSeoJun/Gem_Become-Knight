using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueGem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	float var = 0.5f;
    // Update is called once per frame
    void Update()
    {
		transform.Translate(new Vector2(0, var * Time.deltaTime));
		if (transform.position.y >= 0.5) var = -0.5f;
		if (transform.position.y <= 0) var = 0.5f;
    }
}
