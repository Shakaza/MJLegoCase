using System.ComponentModel.DataAnnotations;

namespace LegoCase.Api.Equipment.Models;

public class CreateEquipmentItemRequest
{
    [Required(AllowEmptyStrings = false)]
    public required string EquipmentItemName { get; set; }
}
