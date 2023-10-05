using LegoCase.Api.Equipment.Models;
using LegoCase.Database.Equipment;

namespace LegoCase.Api;

public static class EquipmentExtensions
{
    public static EquipmentOverviewItemResponse ToOverviewResponse(this EquipmentItem equipmentItem)
    {
        return new EquipmentOverviewItemResponse
        {
            EquipmentItemId = equipmentItem.EquipmentItemId,
            EquipmentItemName = equipmentItem.EquipmentItemName,
            EquipmentState = equipmentItem.State,
            ModifiedAt = equipmentItem.ModifiedAt.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss")
        };
    }

    public static EquipmentItemResponse ToItemResponse(this EquipmentItem equipmentItem)
    {
        return new EquipmentItemResponse
        {
            EquipmentItemId = equipmentItem.EquipmentItemId,
            EquipmentItemName = equipmentItem.EquipmentItemName,
            EquipmentState = equipmentItem.State,
            ModifiedAt = equipmentItem.ModifiedAt.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss"),
            Traces = equipmentItem.Traces.Select(trace => trace.ToResponse()).ToList()
        };
    }

    private static EquipmentTraceResponse ToResponse(this EquipmentTrace equipmentTrace) 
    {
        return new EquipmentTraceResponse
        {
            ChangedAt = equipmentTrace.CreatedAt.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss"),
            NewState = equipmentTrace.NewState,
            PreviousState = equipmentTrace.PreviousState,
            UserName = equipmentTrace.UserName
        };
    }
}
