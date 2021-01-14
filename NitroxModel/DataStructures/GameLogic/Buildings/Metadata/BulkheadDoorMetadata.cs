using System;
using ProtoBufNet;

namespace NitroxModel.DataStructures.GameLogic.Buildings.Metadata
{
    [Serializable]
    [ProtoContract]
    public class BulkheadDoorMetadata : BasePieceMetadata
    {
        [ProtoMember(1)]
        public bool DoorOpen { get; set; }

        protected BulkheadDoorMetadata()
        {
            //Constructor for serialization. Has to be "protected" for json serialization.
        }

        public BulkheadDoorMetadata(bool doorOpen)
        {
            DoorOpen = doorOpen;
        }

        public override string ToString()
        {
            return $"[BulkheadDoorMetadata DoorOpen: {DoorOpen}]";
        }
    }
}
