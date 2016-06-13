using System;
using UnityEngine;

public class MainOverlay : MonoBehaviour
{
	public void DisplayLabs()
	{
		UIWindowController.Instance.SpawnPanel (GameObject.Instantiate (UiAssets.Instance.LabSelectPanel).GetComponent<Panel>());
		
	}

	public void TestSave()
	{
		GameController.Instance.seralizer.Save ("test.bin");
	}

	public void OpenMenu()
	{
	}

	void Update()
	{
	//	if (Input.GetKey ("Cancel")) {
				
	//	}
	}

}


