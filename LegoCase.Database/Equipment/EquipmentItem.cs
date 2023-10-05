using System.ComponentModel.DataAnnotations;

namespace LegoCase.Database.Equipment;

public class EquipmentItem : BaseEntity
{
    [Key]
    public Guid EquipmentItemId { get; set; }
    public string EquipmentItemName { get; set; } = string.Empty;
    public EquipmentItemState State { get; set; }
    public virtual ICollection<EquipmentTrace> Traces { get; set; } = null!;
}
