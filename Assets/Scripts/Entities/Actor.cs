using System;
using UnityEngine;
using BehaviorTree;

public class Actor : MonoBehaviour
{
	protected BehaviorTree.Tree tree;

	protected virtual Node Tree()
	{
		return new Node ();
	}

	protected virtual void Start(){
		tree = new BehaviorTree (Tree);
	}

	protected virtual void FixedUpdate()
	{
	}

	protected virtual void Update()
	{
		
	}
}

