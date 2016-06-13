using System;
using UnityEngine;
using BehaviorTree;
using ProtoBuf;

[ProtoInclude(1,typeof(Employee))]
public class Actor : SerializableBehavior
{
	protected BehaviorTree.Tree tree;
	private bool isDead;

	protected override void Start(){
		base.Start ();
		isDead = true;
		GameController.Instance.ActorCollection.RegisterActor (this);
		this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,-1);
	}

	protected virtual void FixedUpdate()
	{
		if (tree != null) {
			tree.Tick ();
		}
	}

	protected override void Update()
	{
		base.Update ();
	}

	public virtual void Kill()
	{
		isDead = false;
		GameController.Instance.ActorCollection.UnRegister (this);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy ();
	}
}

