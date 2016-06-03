using System;
using ProtoBuf;
using ProtoBuf.Meta;
using UnityEngine;
using System.IO;
using System.Collections.Generic;


public class Seralizer
{
	private SaveData saveData = new SaveData ();


	public Seralizer ()
	{
		//register unity types
		/*MetaType vector2Type =  RuntimeTypeModel.Default.Add(typeof(Vector2),false);
		vector2Type.AddField (1, "x");
		vector2Type.AddField (2, "y");*/

		//RuntimeTypeModel.Default.Add(typeof(Vector3),true).Add(1, "x").Add(2, "y").Add(3, "z");
		//vector3Type.AddField (7, "w");

		//RuntimeTypeModel.Default.Add (typeof(Transform),false).AddField (1, "position");

	
	}

	public string SaveDirectory{
		get{ return Application.persistentDataPath;}
	}


	public void RegisterGameObject(SerializableBehavior behavior) 
	{	
		if (saveData.seralizbleCollection.Contains (behavior)) {
			return;
		}
		saveData.seralizbleCollection.Add (behavior);
	}

	public void DestroyGameObject(SerializableBehavior behavior) 
	{
		saveData.seralizbleCollection.Remove (behavior);
		
	}



	public void RegisterSeralizability(SerializableBehavior behavior)
	{
		RuntimeTypeModel.Default[behavior.GetType()].SetFactory(typeof(Seralizer).GetMethod("Create"));	
	}


	public void Save(string name)
	{
		foreach(SerializableBehavior s in saveData.seralizbleCollection)
		{
			s.OnSerialize();
		}
		using (var file = File.Create(Application.persistentDataPath +Path.DirectorySeparatorChar + name)) {
			Serializer.Serialize(file, saveData);
		}
	}

	public void Load(string name)
	{
		try{
			
			using (var file = File.OpenRead(Application.persistentDataPath +Path.DirectorySeparatorChar + name)) {
				Serializer.Deserialize<SaveData>(file);
			}
		}
		catch(Exception e)
		{
			UnityEngine.Debug.Log (e);
		}
	}

	public static object Create(Type t)
	{
		if (!AssetManager.Instance.Serializible.ContainsKey (t)) {
			return null;
		}
		
		GameObject gameObject =  GameObject.Instantiate (AssetManager.Instance.Serializible [t].gameObject);
		((SerializableBehavior)gameObject.GetComponent (t)).OnDeserialize ();

		return gameObject.GetComponent(t);
	}
		


}


