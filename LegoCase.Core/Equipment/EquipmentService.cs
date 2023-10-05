using LegoCase.Core.Equipment;
using LegoCase.Core.Users;
using LegoCase.Database;
using LegoCase.Database.Equipment;
using Microsoft.EntityFrameworkCore;

namespace LegoCase.Core.Equipment;

public class EquipmentService : IEquipmentService
{
    private readonly LegoCaseContext _context;
    private readonly IUserService _userService;

    public EquipmentService(LegoCaseContext context, IUserService userService)
    {
        _context = context;
        _userService = userService;
    }

    public async Task<EquipmentItem?> ChangeEquipmentStateAsync(Guid equipmentItemId, EquipmentItemState newState)
    {
        var equipment = await GetSpecificEquipmentAsync(equipmentItemId);
        if(equipment == null || equipment.State == newState) return equipment;

        var user = await _userService.GetCurrentUser();

        var equipmentTrace = new EquipmentTrace
        {
            EquipmentItemId = equipmentItemId,
            PreviousState = equipment.State,
            NewState = newState,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow,
            UserName = user.Name
        };

        equipment.State = newState;
        equipment.ModifiedAt = DateTime.UtcNow;

        _context.EquipmentTraces.Add(equipmentTrace);
        await _context.SaveChangesAsync();
        
        return equipment;
    }

    public async Task CreateEquipmentAsync(string equipmentItemName)
    {
        var newEquipment = new EquipmentItem
        {
            EquipmentItemId = Guid.NewGuid(),
            EquipmentItemName = equipmentItemName,
            State = EquipmentItemState.StandingStill,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };

        _context.EquipmentItems.Add(newEquipment);
        await _context.SaveChangesAsync();
    }

    public Task<List<EquipmentItem>> GetAllEquipmentAsync()
    {
        return _context.EquipmentItems.ToListAsync();
    }

    public Task<EquipmentItem?> GetSpecificEquipmentAsync(Guid equipmentItemId)
    {
        return _context.EquipmentItems
            .Include(item => item.Traces)
            .FirstOrDefaultAsync(equipmentItem => equipmentItem.EquipmentItemId == equipmentItemId);
    }
}
