using System;
using ProtoBufNet;

namespace NitroxModel.DataStructures.GameLogic.Buildings.Metadata
{
    [Serializable]
    [ProtoContract]
    [ProtoInclude(50, typeof(SignMetadata))]
    [ProtoInclude(60, typeof(BulkheadDoorMetadata))]
    public abstract class BasePieceMetadata
    {
    }
}
