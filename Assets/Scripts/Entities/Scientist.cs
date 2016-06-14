using System;
using ProtoBuf;
using BehaviorTree;


public class Scientist : Employee
{
	Node HungerBehavior = new Sequence(new Node[]{new FileTilePath<DiningHallRoom>("position","path"),new PathFeed("path","tile",new Node())});
	protected override void Start ()
	{
		base.Start ();
	}

	protected override void Update ()
	{
		
		base.Update ();
	}

}

