import React, { useState, useEffect } from 'react';

import { TableStyle } from './TableStyle'

import { addSeparIndicatorInfo } from './addSeparIndicatorInfo'
import { TableHead } from './TableHead'
import { BodyContainer } from './BodyContainer'
import {
    TableStartWidths,
    StartTableWidth
} from '../../../constants/Constants'

export const Table = ({ TableData, Get_TableInfo }) => {

    //получить размеры столбцов и данные сепаратора по умолчанию
    const getDefColumnSizeData = (TableData) => {
        //данные ширин столбцов
        let DefColumnSizeData = []
        TableData.columnData.forEach(q => {
            //общая ширина всех столбцов по умолчанию
            let column_w = StartTableWidth
            if (TableStartWidths.has(q.headerPropName)) {
                //ширина столбца из коллекции
                column_w = TableStartWidths.get(q.headerPropName)
            }
            //создание объекта с настройками столбцов
            let SizeData = {}
            SizeData.headerPropName = q.headerPropName//имя столбца
            SizeData.column_w = column_w//ширина столбца
            DefColumnSizeData.push(SizeData)
        })
        addSeparIndicatorInfo(DefColumnSizeData, false)
        return DefColumnSizeData
    }
    //получить состояние таблицы по умолчанию
    const getTableState = (TableData) => {
        const defTableState = {
            TableData: TableData,
            ColumnSizeData: getDefColumnSizeData(TableData),
            disabled: false,
            BodyContainerOverflowX: true,
            deleteMode: false
        }
        return defTableState
    }
    //данные ширин столбцов и данные сепаратора
    const [TableState, setTableState] = useState(getTableState(TableData))
    //объект состояния для передачи в компоненты
    let TableInfo =
    {
        TableState: TableState,
        setTableState: setTableState
    }
    //передать объект состояния в родительский компонент
    useEffect(() => {
        Get_TableInfo(TableInfo)
    }, [])
    //стили
    const cls = TableStyle(
        {
            deleteMode: TableInfo.TableState.deleteMode,
            disabled: TableInfo.TableState.disabled
        })

    return (
        <div class={cls.Table}>
            <TableHead TableInfo={TableInfo} />
            <BodyContainer TableInfo={TableInfo} />
        </div>
    )
}
