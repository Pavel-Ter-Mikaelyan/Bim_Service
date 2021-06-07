import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import { TableManagerContainer } from './TableManagerContainer'
import { Table } from './Table/Table'
import {
    TableStartWidths,
    StartTableWidth
} from '../../constants/Constants'
import { addSeparIndicatorInfo } from './Table/SharedMethods/addSeparIndicatorInfo'

//стили
const TablePanelStyles = createUseStyles({
    TablePanel: {
        display: 'flex',
        flexFlow: 'column nowrap',
        overflow: 'hidden',
        '& >.TableManagerContainer': {
            display: 'flex',
            alignItems: 'center',
            minHeight: 40,
        },
    }
})

//пример данных в таблице ДЛЯ ТЕСТА
const TableData = {
    tableName: 'Динамическая таблица',
    rowIds: [10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20],
    columnData: [
        {
            type: '0',//текст
            headerName: 'Столбец 1',
            headerPropName: 'prop2',
            defVal: 'знач. по умолч.',
            rowVals: [{ value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач2' }, { value: 'знач3' }]
        },
        {
            type: 1,//список
            headerName: 'Столбец 2',
            headerPropName: 'prop1',
            defVal: 5,
            comboboxData: [1, 2, 3, 4, 5, 6, 7, 8, 9, 'текст'],
            rowVals: [{ value: 'текст' }, { value: 'текст' }, { value: 'текст' }, { value: 'текст' }, { value: 'текст' }, { value: 'текст' }, { value: 'текст' }, { value: 'текст' }, { value: 'текст' }, { value: '1' }, { value: '2' }]
        },
        {
            type: 2,//чекбокс
            headerName: 'Столбец 3',
            headerPropName: 'prop3',
            defVal: false,
            rowVals: [{ value: true }, { value: true }, { value: true }, { value: true }, { value: true }, { value: true }, { value: true }, { value: true }, { value: true }, { value: false }, { value: true }]
        }
    ]
}

export const TablePanel = () => {

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
    //получить данные главной таблицы
    const getMainTableData = (TableData) => {
        //сформировать данные главной таблицы
        const MainTableData = {
            TableData: TableData,
            ColumnSizeData: getDefColumnSizeData(TableData),
        }
        return MainTableData
    }
    //получить данные таблицы новых строк 
    const getNewRowTableData = (TableData) => {
        //создать данные таблицы новых строк на основе TableData
        let newTableData = { ...TableData }
        newTableData.tableName = 'Добавить новую строку'
        newTableData.rowIds = [-1]
        newTableData.columnData =
            TableData.columnData.map(columnData => ({ ...columnData }))
        newTableData.columnData.forEach((columnData) => {
            columnData.rowVals = [{ value: columnData.defVal }]
        })
        //сформировать данные таблицы новых строк
        const NewRowTableData = {
            TableData: newTableData,
            ColumnSizeData: getDefColumnSizeData(newTableData),
        }
        return NewRowTableData
    }
    //получить состояние по умолчанию
    const getDefTableState = (TableData) => {
        return {
            MainTableData: getMainTableData(TableData),
            NewRowTableData: getNewRowTableData(TableData),
            disabled: true,
            deleteMode: false
        }
    }

    //данные таблицы
    const [TableState, setTableState] =
        useState(getDefTableState(TableData))

    //объект состояния для передачи в компоненты
    const TableInfo =
    {
        TableState: TableState,
        setTableState: setTableState
    }
    let MainTableInfo = { ...TableInfo }
    let NewRowTableInfo = { ...TableInfo }
    MainTableInfo.newRowMode = false
    NewRowTableInfo.newRowMode = true
   
    //стили
    const cls = TablePanelStyles();

    return (
        <div class={cls.TablePanel} >
            <TableManagerContainer TableInfo={TableInfo} />
            <Table TableInfo={NewRowTableInfo} />
            <Table TableInfo={MainTableInfo} />
        </div>
    )
}