using LegoCase.Database.Equipment;

namespace LegoCase.Core.Equipment;

public interface IEquipmentService
{
    Task<List<EquipmentItem>> GetAllEquipmentAsync();
    Task<EquipmentItem?> GetSpecificEquipmentAsync(Guid equipmentItemId);
    Task CreateEquipmentAsync(string equipmentItemName);
    Task<EquipmentItem?> ChangeEquipmentStateAsync(Guid equipmentItemId, EquipmentItemState newState);
}
