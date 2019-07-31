using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
	public GameObject Pause;
	bool isP = false;
    // Start is called before the first frame update
    void Start()
    {
		Pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!isP)
			{
				Time.timeScale = 0;
				Pause.SetActive(true);
				isP = true;
			}
			else
			{
				Time.timeScale = 1;
				Pause.SetActive(false);
				isP = false;
			}
		}
    }
}
