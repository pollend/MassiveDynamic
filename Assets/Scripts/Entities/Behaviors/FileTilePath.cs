using System;
using BehaviorTree;
using UnityEngine;
using System.Collections.Generic;

public class FileTilePath<T> : Node   
{
	public class TileNode
	{

		public TileContainer Main { get; private set; }
		public TileNode Parent{ get; private set; }
		public TileNode(TileContainer main, TileNode parent)
		{
			this.Main = main;
			this.Parent = parent;
		}
	}

	private String outputMapping;
	private String startPos;
	private List<TileNode> tiles = new List<TileNode> ();
	private List<ITileContainer> exclude = new List<ITileContainer> ();


	public FileTilePath (String startPos,String output)
	{
		this.outputMapping = output;
		this.startPos = startPos;

	}

	public override void Initialize (DataContext context)
	{
		Vector2 pos = (Vector2)context.GetValue (startPos);
		tiles.Add( new TileNode(GameController.Instance.Map.GetTile (Mathf.FloorToInt (pos.x), Mathf.FloorToInt (pos.y)),null));
		base.Initialize (context);
	}

	public override Result Run (DataContext context)
	{
		//GameController.Instance.Map.GetTile (Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y));
		if (tiles.Count > 0) {
			TileNode t = tiles [0];
			foreach (TileContainer tile in t.Main.Tile.connections ()) {
				if (!exclude.Contains (tile)) {
					TileNode tileNode = new TileNode (tile, t); 
					tiles.Add (tileNode);
					exclude.Add (tile);
					if (tile is T) {
						
						Stack<TileContainer> path = new Stack<TileContainer> ();
						TileNode tn = tileNode;
						while (true) {
							path.Push (tn.Main);
							if (tn.Parent == null) {
								break;
							}
							tn = tn.Parent;

						}
						context.SetValue (outputMapping, path);
						return Result.SUCCESS;

					}
				}
			}
			tiles.RemoveAt (0);
		} else {
			return Result.FAILED;
		}
		return Result.RUNNING;
	}

	public override void Handle (Result result, DataContext context, Node previous)
	{
		base.Handle (result, context, previous);
	}
}
