using System;
using ProtoBuf;

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

}

