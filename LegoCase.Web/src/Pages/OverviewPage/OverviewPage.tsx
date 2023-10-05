import { For, Show, createResource } from "solid-js"
import { fetchEquipmentOverview } from "../../Services/EquipmentService";
import { EquipmentState } from "../../Domain/Equipment";

import './OverviewPage.scss'

function getClassForState(state: EquipmentState) {
    switch(state) {
        case "PoweringUp":
        case "WindingDown":
            return "color-yellow";
        case "ProducingNormally":
            return "color-green";
        case "StandingStill":
            return "color-red";
    }
}

export function OverviewPage() {
    const [equipmentOverviewItems] = createResource(fetchEquipmentOverview);

    return <>
        <Show when={equipmentOverviewItems.state !== "ready"}>
            <div>Loading...</div>
        </Show>
        <Show when={equipmentOverviewItems.state === "ready" && equipmentOverviewItems()}>
            <table class="equipment-overview-table">
                <thead>
                    <tr>
                        <td class="table-header">Equipment Name</td>
                        <td class="table-header">Last state change</td>
                        <td class="table-header">Equipment State</td>
                    </tr>
                </thead>
                <tbody>
                    <For each={equipmentOverviewItems()?.equipmentItems}>{(item) =>
                        <tr>
                            <td>{item.equipmentItemName}</td>
                            <td>{item.modifiedAt}</td>
                            <td class={"equipment-state " + getClassForState(item.equipmentState)}></td>
                        </tr>
                    }</For>
                </tbody>
            </table>
        </Show>
    </>
}