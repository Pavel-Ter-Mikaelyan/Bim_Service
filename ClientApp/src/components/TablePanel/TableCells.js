import React, { useState, useEffect } from 'react';

import { Checkbox } from './Components/Checkbox';
import { Combobox } from './Components/Combobox';
import { Textbox } from './Components/Textbox';

export const TableCells = ({ columnInfo, disabled }) => {

    let className = ""
    let component = null;
    let comboboxData = null;

    //если тип ячейки 'Textbox'
    if (columnInfo.type == 0) {
        className = "Textbox"
        component = Textbox;
    }
    //если тип ячейки 'Combobox'
    if (columnInfo.type == 1) {
        className = "Combobox"
        component = Combobox
        comboboxData = columnInfo.comboboxData
    }
    //если тип ячейки 'Checkbox'
    if (columnInfo.type == 2) {
        className = "Checkbox"
        component = Checkbox
    }

    const Cell = (valueObj) => {
        const ComponentData = {};
        ComponentData.valueObj = valueObj
        ComponentData.disabled = disabled
        ComponentData.comboboxData = comboboxData
        return (
            <div class={className} >
                {component({ ComponentData: ComponentData })}
            </div >
        )
    }
    const Cells = columnInfo.rowVals.map(valueObj => Cell(valueObj))

    return Cells
}