import React, { useState, useEffect } from 'react';

import { TableStyle } from './TableStyle'

import { addSeparIndicatorInfo } from './addSeparIndicatorInfo'
import { TableHead } from './TableHead'
import { BodyContainer } from './BodyContainer'
import {
    TableStartWidths,
    StartTableWidth
} from '../../../constants/Constants'

export const Table = ({TableData}) => {
    const cls = TableStyle()
    const disabled = false

    //данные ширин столбцов
    let DefaultColumnSizeData = []
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
        DefaultColumnSizeData.push(SizeData)
    })
    addSeparIndicatorInfo(DefaultColumnSizeData, false)

    //объект для передачи в подкомпоненты
    let defTableState = {
        ColumnSizeData: DefaultColumnSizeData,
        TableData: TableData,
        disabled: disabled,
        BodyContainerOverflowX: true
    }

    //данные ширин столбцов и данные сепаратора
    const [TableState, setTableState] = useState(defTableState)
    const TableInfo = {
        TableState: TableState,
        setTableState: setTableState
    }

    return (
        <div class={cls.Table} >
            {TableHead(TableInfo)}
            {BodyContainer(TableInfo)}
        </div>
    )
}
