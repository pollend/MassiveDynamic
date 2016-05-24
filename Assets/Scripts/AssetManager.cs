using System;
using UnityEngine;

[CreateAssetMenuAttribute]
public class AssetManager: ScriptableSingleton<AssetManager>
{
	[SerializeField]
	public GameObjectContainer Rooms;


}
