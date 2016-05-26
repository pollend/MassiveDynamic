using System;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenuAttribute]
public class AssetManager: ScriptableSingleton<AssetManager>
{
	[SerializeField]
	public GameObjectContainer seralizableObjects;

	//TODO: REDO all of this
	public Dictionary<Type,Lab> Labs = new Dictionary<Type, Lab>();

	public Dictionary<Type,Tile> Tiles = new Dictionary<Type, Tile>();

	public Dictionary<Type,SerializableBehavior> Serializible = new Dictionary<Type, SerializableBehavior>();

	public void Initialize()
	{
		foreach(GameObject gameObject in seralizableObjects.GameObjects)
		{
			SerializableBehavior item = gameObject.GetComponent<SerializableBehavior> ();

			//register object as being seralizible
			GameController.Instance.seralizer.RegisterSeralizability (item);

			if (item is Lab)
				Labs.Add (item.GetType (), (Lab)item);
			if (item is Tile)
				Tiles.Add (item.GetType (), (Tile)item);
			Serializible.Add (item.GetType (), item);
			
		}

	}

/*	public T Create<T>() where T: SerializableBehavior,new()
	{
		return new T();
	}*/


}
