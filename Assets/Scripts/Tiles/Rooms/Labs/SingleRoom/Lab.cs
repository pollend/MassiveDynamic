using System;
using ProtoBuf;
using UnityEngine;

[ProtoContract]
[ProtoInclude(1,typeof(AnimalRoom))]
[ProtoInclude(2,typeof(ArcheologyRoom))]
[ProtoInclude(3,typeof(BiologyRoom))]
[ProtoInclude(4,typeof(ChemRoom))]
[ProtoInclude(5,typeof(MathRoom))]
[ProtoInclude(6,typeof(MorgueRoom))]
[ProtoInclude(7,typeof(ObservatoryRoom))]
[ProtoInclude(8,typeof(ParticleRoom))]
[ProtoInclude(9,typeof(PhysicsRoom))]
[ProtoInclude(10,typeof(RoboticsRoom))]
[ProtoInclude(11,typeof(SampleLab))]
public class Lab : Structure
{
	

	public override void OnClick (int mouseButton)
	{
		UIWindowController.Instance.SpawnPanel (GameObject.Instantiate (UiAssets.Instance.LabSinglePanel).GetComponent<Panel>());

		base.OnClick (mouseButton);
	}

	protected override void Start ()
	{
		GameObject gameObject =  UnityEngine.GameObject.Instantiate (AssetManager.Instance.seralizableObjects.GetGameObjectByName ("Scientist"));
		Vector2 pos = new Vector2 (this.transform.position.x, this.transform.position.y);
		gameObject.transform.position = GetRelativeOrigin () + pos;

		base.Start ();
	}


}

