using System.ComponentModel.DataAnnotations;
using LegoCase.Api.Equipment.Models;
using LegoCase.Core.Equipment;
using LegoCase.Database.Equipment;
using Microsoft.AspNetCore.Mvc;

namespace LegoCase.Api.Equipment;

[Route("api/equipment")]
public class EquipmentController : Controller
{
    private readonly IEquipmentService _equipmentService;

    public EquipmentController(IEquipmentService equipmentService)
    {
        _equipmentService = equipmentService;
    }

    [HttpGet]
    public async Task<ActionResult<EquipmentOverviewResponse>> GetEquipmentOverview()
    {
        var equipmentItems = await _equipmentService.GetAllEquipmentAsync();
        var response = new EquipmentOverviewResponse
        {
            EquipmentItems = equipmentItems.Select(equipmentItem => equipmentItem.ToOverviewResponse()).ToList()
        };
        return Ok(response);
    }

    [HttpGet("{equipmentItemId}")]
    public async Task<ActionResult<EquipmentItemResponse>> GetEquipmentItem([FromRoute, Required] Guid equipmentItemId)
    {
        var equipmentItem = await _equipmentService.GetSpecificEquipmentAsync(equipmentItemId);
        if(equipmentItem == null) return NotFound();

        return Ok(equipmentItem.ToItemResponse());
    }

    [HttpPost]
    public async Task<ActionResult> CreateEquipmentItem([FromBody, Required] CreateEquipmentItemRequest request)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);

        await _equipmentService.CreateEquipmentAsync(request.EquipmentItemName);
        return Ok();
    }

    [HttpPost("{equipmentItemId}/change-state/{newStateString}")]
    public async Task<ActionResult<EquipmentItemResponse>> ChangeEquipmentState([FromRoute, Required] Guid equipmentItemId, [FromRoute, Required] string newStateString)
    {
        if(!Enum.TryParse<EquipmentItemState>(newStateString, true, out var newState)) return BadRequest($"Invalid state {newStateString}.");

        var updatedEquipment = await _equipmentService.ChangeEquipmentStateAsync(equipmentItemId, newState);

        if(updatedEquipment == null) return NotFound();
        
        return Ok(updatedEquipment.ToItemResponse());
    }
}
