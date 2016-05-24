using System;
using UnityEngine;

public class MainOverlay : MonoBehaviour
{
	public void DisplayLabs()
	{
		UIWindowController.Instance.SpawnPanel (GameObject.Instantiate (UiAssets.Instance.LabSelectPanel).GetComponent<Panel>());
		
	}

}


