export type EquipmentOverviewResponse = {
    equipmentItems: EquipmentOverviewItemResponse[]
}

export type EquipmentOverviewItemResponse = {
    equipmentItemId: string,
    equipmentItemName: string,
    equipmentState: EquipmentState,
    modifiedAt: string
}

export type EquipmentState = "StandingStill" | "PoweringUp" | "WindingDown" | "ProducingNormally"