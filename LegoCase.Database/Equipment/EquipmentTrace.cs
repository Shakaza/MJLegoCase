using System.ComponentModel.DataAnnotations;

namespace LegoCase.Database.Equipment;

public class EquipmentTrace : BaseEntity
{
    [Key]
    public Guid EquipmentTraceId { get; set; }

    public Guid EquipmentItemId { get; set; }
    public virtual EquipmentItem EquipmentItem { get; set; } = null!;

    public EquipmentItemState PreviousState { get; set; }
    public EquipmentItemState NewState { get; set; }

    public string UserName { get; set; } = string.Empty;
}