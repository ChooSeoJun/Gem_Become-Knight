using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemONOFF : MonoBehaviour
{
	public GameObject 쥄;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		쥄.SetActive(!GEM.mons);
    }
}
