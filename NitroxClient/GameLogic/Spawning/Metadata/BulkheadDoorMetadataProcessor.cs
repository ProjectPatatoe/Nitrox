using NitroxClient.MonoBehaviours;
using NitroxModel.DataStructures;
using NitroxModel.DataStructures.GameLogic.Buildings.Metadata;
using UnityEngine;

namespace NitroxClient.GameLogic.Bases.Metadata
{
    class BulkheadDoorMetadataProcessor : GenericBasePieceMetadataProcessor<BulkheadDoorMetadata>
    {
        public override void UpdateMetadata(NitroxId id, BulkheadDoorMetadata metadata)
        {
            GameObject gameObject = NitroxEntity.RequireObjectFrom(id);
            BulkheadDoor door = gameObject.GetComponentInChildren<BulkheadDoor>();
            //BulkheadDoor.targetState = metadata.DoorClosed;

            door.SetState(metadata.DoorOpen);
        }
    }
}
