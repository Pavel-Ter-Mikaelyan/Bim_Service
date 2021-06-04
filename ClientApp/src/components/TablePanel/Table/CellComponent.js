import React, { useState, useEffect } from 'react';

import { Checkbox } from '../CellComponents/Checkbox';
import { Combobox } from '../CellComponents/Combobox';
import { Textbox } from '../CellComponents/Textbox';

export const CellComponent = ({ TableInfo, ColumnIndex, RowIndex }) => {

    const columnInfo = TableInfo.TableState.MainTableData.TableData.columnData[ColumnIndex]
    const ComponentData = {};
    ComponentData.valueObj = columnInfo.rowVals[RowIndex]
    ComponentData.disabled = TableInfo.TableState.disabled
    //событие изменения значения в ячейке
    ComponentData.onChange = (e, type) => {
        if (ComponentData.disabled) return;
        if (type == 'Checkbox') {
            ComponentData.valueObj.value =
                !ComponentData.valueObj.value
        }
        if (type == 'Combobox' || type == 'Textbox') {
            if (e !== undefined) {
                ComponentData.valueObj.value = e.target.value
            }
        }       
        //применить изменения
        TableInfo.setTableState({ ...TableInfo.TableState })
    }
   
    //если тип ячейки 'Textbox'
    if (columnInfo.type == 0) {
        return <Textbox ComponentData={ComponentData} />
    }
    //если тип ячейки 'Combobox'
    if (columnInfo.type == 1) {
        ComponentData.comboboxData = columnInfo.comboboxData
        return <Combobox ComponentData={ComponentData} />
    }
    //если тип ячейки 'Checkbox'
    if (columnInfo.type == 2) {
        return <Checkbox ComponentData={ComponentData} />
    }
    return null
}