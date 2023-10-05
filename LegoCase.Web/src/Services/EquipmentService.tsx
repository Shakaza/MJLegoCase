import { EquipmentOverviewResponse } from "../Domain/Equipment";
import { get } from "../Helpers/Api";

export function fetchEquipmentOverview() : Promise<EquipmentOverviewResponse> {
    return get("/api/equipment");
}