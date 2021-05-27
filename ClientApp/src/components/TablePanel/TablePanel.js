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
    tableName: 'Динамическая таблица готова',
    rowIs: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
    columnData: [
        {
            type: '0',//текст
            headerName: 'Столбец 1',
            headerPropName: 'prop2',
            defVal: 'знач. по умолч.',
            rowVals: [{ value: 'знач1rgieonr;oirtnh;trdhn;dfthnft;ohidnfthoin;hiodtf' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач2' }, { value: 'знач3' }]
        },
        {
            type: 1,//список
            headerName: 'Столбец 2',
            headerPropName: 'prop1',
            defVal: 5,
            comboboxData: [1, 2, 3, 4, 5, 6, 7, 8, 9, '9ykygklhlhlufyklfuhluglguluhlugl'],
            rowVals: [{ value: '9ykygklhlhlufyklfuhluglguluhlugl' }, { value: '9' }, { value: '9' }, { value: '9' }, { value: '9' }, { value: '9' }, { value: '9' }, { value: '9' }, { value: '1' }, { value: '3' }]
        },
        {
            type: 2,//чекбокс
            headerName: 'Столбец 3',
            headerPropName: 'prop3',
            defVal: false,
            rowVals: [{ value: true }, { value: true }, { value: true }, { value: true }, { value: true }, { value: true }, { value: true }, { value: true }, { value: false }, { value: true }]
        }
    ]
}

export const TablePanel = () => {
    const cls = TablePanelStyles();

    return (
        <div class={cls.TablePanel} >
            <TableManagerContainer />
            <TableNewRowContainer />
            <Table TableData={TableData}/>
        </div>
    )
}