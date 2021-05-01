import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import { TableColumn } from './TableColumn'

const TableStyle = createUseStyles({
    Table: {
        display: 'flex',
    }
})

const TableData = {
    tableName: 'Таблица',
    rowIs: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
    columnData: [
        {
            type: 1,
            headerName: 'Столбец 1',
            headerPropName: 'prop1',
            defVal: 5,
            comboboxData: [1, 2, 3, 4, 5, 6, 7, 8, 9, '9ykygklhlhlufyklfuhluglguluhlugl'],
            rowVals: [{ value: '9ykygklhlhlufyklfuhluglguluhlugl' }, { value: '9' }, { value: '9' }, { value: '9' }, { value: '9' }, { value: '9' }, { value: '9' }, { value: '9' }, { value: '1' }, { value: '3' }]
        },
        {
            type: '0',
            headerName: 'Столбец 2',
            headerPropName: 'prop2',
            defVal: 'знач. по умолч.',
            rowVals: [{ value: 'знач1rgieonr;oirtnh;trdhn;dfthnft;ohidnfthoin;hiodtf' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач2' }, { value: 'знач3' }]
        },
        {
            type: 2,
            headerName: 'Столбец 3',
            headerPropName: 'prop3',
            defVal: false,
            rowVals: [{ value: true }, { value: true }, { value: true }, { value: true }, { value: true }, { value: true }, { value: true }, { value: true }, { value: false }, { value: true }]
        }
    ]
}

export const Table = () => {
    const cls = TableStyle()
    const disabled = false

    const Columns =
        TableData.columnData
            .map(columnInfo =>
                TableColumn({ columnInfo: columnInfo, disabled: disabled }))

    return (
        <div class={cls.Table}>           
            {Columns}
        </div>
    )
}
