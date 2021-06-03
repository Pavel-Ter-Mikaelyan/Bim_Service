import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import { TableManagerContainer } from './TableManagerContainer'
import { TableNewRowContainer } from './TableNewRowContainer'
import { Table } from './Table/Table'

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
        '& >.TableNewRowContainer': {
            minHeight: 40
        },
    }
})

//пример данных в таблице ДЛЯ ТЕСТА
const TableData = {
    tableName: 'Динамическая таблица',
    rowIds: [10, 11, 12],
    columnData: [
        {
            type: '0',//текст
            headerName: 'Столбец 1',
            headerPropName: 'prop2',
            defVal: 'знач. по умолч.',
            rowVals: [{ value: 'знач1' }, { value: 'знач2' }, { value: 'знач3' }]
        },
        {
            type: 1,//список
            headerName: 'Столбец 2',
            headerPropName: 'prop1',
            defVal: 5,
            comboboxData: [1, 2, 3, 4, 5, 6, 7, 8, 9, 'текст'],
            rowVals: [{ value: 'текст' }, { value: '1' }, { value: '2' }]
        },
        {
            type: 2,//чекбокс
            headerName: 'Столбец 3',
            headerPropName: 'prop3',
            defVal: false,
            rowVals: [{ value: true }, { value: false }, { value: true }]
        }
    ]
}

export const TablePanel = () => {
    //стили
    const cls = TablePanelStyles();
    //объект состояния таблицы
    let TableInfo = null

    const onClick = () => {
        if (TableInfo == null) {return}
        TableInfo.TableState.disabled = !TableInfo.TableState.disabled
        //применить изменения      
        TableInfo.setTableState({ ...TableInfo.TableState })
    }

    //получить объект состояния таблицы из дочернего компонента
    const Get_TableInfo = (TI) => {
        TableInfo = TI
    }

    return (
        <div class={cls.TablePanel} >
            <p onClick={onClick}>Тест кнопки режима редактирования</p>
            <TableManagerContainer />
            <TableNewRowContainer />
            <Table
                TableData={TableData}
                Get_TableInfo={Get_TableInfo}
            />
        </div>
    )
}