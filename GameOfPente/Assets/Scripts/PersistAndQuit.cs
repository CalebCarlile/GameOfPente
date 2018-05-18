using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistAndQuit : MonoBehaviour 
{
	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	void Update()
	{
		if(Input.GetKeyUp(KeyCode.Space))
		{
			Application.Quit();
		}
	}

}
