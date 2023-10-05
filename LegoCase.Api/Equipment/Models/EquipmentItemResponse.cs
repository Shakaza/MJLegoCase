using System.Text.Json.Serialization;
using LegoCase.Database.Equipment;

namespace LegoCase.Api.Equipment.Models;

public class EquipmentItemResponse
{
    public required Guid EquipmentItemId { get; set; }

    public required string EquipmentItemName { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required EquipmentItemState EquipmentState { get; set; }
    public required string ModifiedAt { get; set; }
    public required List<EquipmentTraceResponse> Traces { get; set; }
}
