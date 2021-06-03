import { addSeparIndicatorInfo } from './addSeparIndicatorInfo';
import {
    TableStartWidths,
} from '../../../constants/Constants'

export const changeColumnForDelete = (TableInfo) => {
    //если активен режим удаления
    if (TableInfo.TableState.deleteMode) {
        //добавить столбец для выбора удаляемых строк в коллекцию columnData
        TableInfo.TableState.TableData.columnData.unshift(
            {
                type: 2,//чекбокс
                headerName: 'Удалить',
                headerPropName: 'prop0',
                defVal: false,
                rowVals: TableInfo.TableState
                    .TableData
                    .rowIds.map(() => ({ value: false }))
            }
        )
        //добавить столбец для выбора удаляемых строк в ColumnSizeData
        let SizeData = {}
        SizeData.headerPropName = 'prop0'//имя столбца
        SizeData.column_w = TableStartWidths.get('prop0')//ширина столбца
        TableInfo.TableState.ColumnSizeData.unshift(SizeData)
    } else {
        //удаление столбца выбора удаляемых строк
        TableInfo.TableState.TableData.columnData.splice(0, 1)
        TableInfo.TableState.ColumnSizeData.splice(0, 1)
    }
    //добавить дополнительную информацию для сепаратора
    addSeparIndicatorInfo(TableInfo.TableState.ColumnSizeData, false)
    //применить изменения      
    TableInfo.setTableState({ ...TableInfo.TableState })
}