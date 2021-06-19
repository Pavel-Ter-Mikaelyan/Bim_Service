import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';
import { connect } from 'react-redux'

import { TableManagerContainer } from './TableManagerContainer'
import { Table } from './Table/Table'
import {
    TableStartWidths,
    StartTableWidth
} from '../../constants/Constants'
import { addSeparIndicatorInfo } from './Table/SharedMethods/addSeparIndicatorInfo'
import { LoadTreeNodesData, LoadTableData } from '../../actions/Index'

//стили
const TablePanelStyles = createUseStyles({
    TablePanel: {
        display: 'flex',
        flexFlow: 'column nowrap',
        overflow: 'hidden',
        '& >.TableManagerContainer': {
            display: 'flex',
            alignItems: 'start',
            '& >div': {
                margin: '12px 0 0 0'
            }
        },
    }
})

const TablePanel = ({
    TableData,
    LoadTableData,
    LoadTreeNodesData
}) => {
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
        if (TableData == null) return null
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

    useEffect(() => {
        setTableState(getDefTableState(TableData))
    }, [TableData])

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

    if (TableState == null || TableData == null) return null

    const NewRowTable = TableData.bAddNewRow ?
        <Table TableInfo={NewRowTableInfo} /> : null

    return (
        <div class={cls.TablePanel} >
            <TableManagerContainer
                TableInfo={TableInfo}
                LoadTableData={LoadTableData}
                LoadTreeNodesData={LoadTreeNodesData}
            />
            {NewRowTable}
            <Table TableInfo={MainTableInfo} />
        </div>
    )
}

//присоединить состояние
const mapStateToProps = (state) => ({
    TableData: state.TablePanelInfo.TableData
})
const mapDispatchToProps = (dispatch) => ({
    LoadTreeNodesData: (SelectedId) => LoadTreeNodesData(dispatch, SelectedId),
    LoadTableData: (SelectedId) => LoadTableData(dispatch, SelectedId)
})
export default connect(mapStateToProps, mapDispatchToProps)(TablePanel)