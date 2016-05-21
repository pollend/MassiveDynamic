using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField]
	public PlacementController PlacementController;

	public static GameController GetGameController()
	{
		return GameObject.Find("_root").GetComponent<GameController>();
	}

	
}

