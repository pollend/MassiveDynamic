using System;
using BehaviorTree;
using UnityEngine;


public class MoveToPoint : Node
{

	private string inputPoint;
	public MoveToPoint (string inputPoint)
	{
		this.inputPoint = inputPoint;
	}

	public override Result Run (DataContext context)
	{
		Actor actor = context.actor;

		Vector2 point = (Vector3)context.GetValue(inputPoint);
		Vector2 actorPos = new Vector2 (actor.gameObject.transform.position.x, actor.gameObject.transform.position.y);

		Vector2 dir =  (point - new Vector2(actor.gameObject.transform.position.x,actor.gameObject.transform.position.y)).normalized;
		actor.RigidBody.AddForce (dir);
		if (Vector2.Distance (point, actorPos) < .1f) {
			return Result.SUCCESS;
		}
		return Result.RUNNING;
	}

}


