using System;
using System.Collections.Generic;
using ProtoBuf;
using System.Linq;

[ProtoContract]
[System.Serializable]
public class ActorCollection
{
	private List<Actor> actors = new List<Actor>();

	public ActorCollection ()
	{
		
	}

	public void RegisterActor(Actor actor)
	{
		actors.Add (actor);
	}

	public void UnRegister(Actor actor)
	{
		actors.Remove (actor);
	}

	public Scientist[] GetScientiest()
	{
		return actors.OfType<Scientist> ().ToArray ();
	}




}


