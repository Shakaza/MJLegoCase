using System.Text.Json.Serialization;
using LegoCase.Database.Equipment;

namespace LegoCase.Api.Equipment.Models;

public class EquipmentTraceResponse
{
    public required string ChangedAt { get; set; }

    public required string UserName { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required EquipmentItemState PreviousState { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required EquipmentItemState NewState { get; set; }
}