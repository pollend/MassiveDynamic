using System;
using UnityEngine;
using BehaviorTree;

public class Actor : MonoBehaviour
{
	protected BehaviorTree.Tree tree;


	protected virtual void Start(){
	}

	protected virtual void FixedUpdate()
	{
		if (tree != null) {
			tree.Tick ();
		}
	}

	protected virtual void Update()
	{
		
	}
}

