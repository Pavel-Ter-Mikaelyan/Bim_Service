import { Checkbox } from '../CellComponents/Checkbox';
import { Combobox } from '../CellComponents/Combobox';
import { Textbox } from '../CellComponents/Textbox';

export const CellComponent = (TableInfo, ColumnIndex, RowIndex) => {
    let component = null;
    let comboboxData = null;
    let columnInfo = TableInfo.TableState.TableData.columnData[ColumnIndex]

    //если тип ячейки 'Textbox'
    if (columnInfo.type == 0) {
        component = Textbox;
    }
    //если тип ячейки 'Combobox'
    if (columnInfo.type == 1) {
        component = Combobox
        comboboxData = columnInfo.comboboxData
    }
    //если тип ячейки 'Checkbox'
    if (columnInfo.type == 2) {
        component = Checkbox
    }

    const ComponentData = {};
    ComponentData.valueObj = columnInfo.rowVals[RowIndex]
    ComponentData.disabled = TableInfo.TableState.disabled
    ComponentData.comboboxData = comboboxData

    return component({ ComponentData: ComponentData })
}