import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import CheckBoxOutlinedIcon from '@material-ui/icons/CheckBoxOutlined';

import { Checkbox } from './Components/Checkbox';
import { Combobox } from './Components/Combobox';
import { Textbox } from './Components/Textbox';

import {
    TableStartWidths,
    StartTableWidth,
    BoldLineStyle
} from '../../constants/Constants'

const TableData = {
    tableName: 'Таблица Таблица Таблица',
    rowIs: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
    columnData: [
        {
            type: 1,
            headerName: 'Столбец 1 Столбец 1 Столбец 1',
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

//стили
const TableStyle = createUseStyles({
    Table: {
        display: 'flex',
        flexFlow: 'column nowrap',
        overflow: 'hidden',
        height: '100%',
        '& >.TableHead': {
            display: 'flex',
            justifyContent: 'space-between',
            alignItems: 'center',
            '& >.HeadText': {
                display: 'flex',
                alignItems: 'center',
                userSelect: 'none',
            },
            '& >.HeadMenu': {
                display: 'flex',
                alignItems: 'center'
            },
        },
        '& >.BodyContainer': {
            display: 'flex',
            flexFlow: 'column nowrap',
            alignItems: 'flex-start',
            height: '100%',
            border: BoldLineStyle,
            borderRadius: 12,           
            overflowX: 'auto',
            overflowY: 'hidden',
            '& >.BodyHead': {
                display: 'flex',
                '& >.BodyCell': {
                    display: 'flex',
                    '& >.CellContent': { 
                        display: 'flex',
                        alignItems: 'center',
                        justifyContent: 'center',
                        width: 200,
                        borderBottom: BoldLineStyle,
                        //текст заголовка столбцов
                        '& >p': {
                            margin: 5,
                            textAlign: 'center',
                            userSelect: 'none'
                        }
                    }
                }
            },
            '& >.TableBody': {
                overflowX: 'hidden',
                overflowY: 'auto',
                height: '100%',
                '& >.BodyRow': {
                    display: 'flex',
                    '& >.BodyCell': {
                        display: 'flex',
                        '& >.CellContent': {
                            display: 'flex',
                            alignItems: 'center',
                            width: 200,
                            height: 25,
                            borderBottom: BoldLineStyle,
                        }
                    },
                    '&:hover': {
                        boxShadow: '0 0 3px 2px rgba(156,117,114,0.8)'
                    }
                }
            }
        },
        '& .CellSepar': {
            width: 3,
            cursor: 'col-resize',
            background: 'rgba(156,117,114,0.8)',
        }
    }
})

const TableHead = ({ TableData, disabled }) => {

    return (
        <div class='TableHead'>
            <div class='HeadText'>
                <p>{TableData.tableName}</p>
            </div>
            <div class='HeadMenu'>
                <CheckBoxOutlinedIcon />
                <p>Удаление </p>
            </div>
        </div>
    )
}

const BodyContainer = ({ ColumnSize, setColumnSize, TableData, disabled }) => {
    return (
        <div class='BodyContainer'>
            <BodyHead
                ColumnSize={ColumnSize}
                setColumnSize={setColumnSize}
                TableData={TableData}
                disabled={disabled}
            />
            <TableBody
                TableData={TableData}
                disabled={disabled}
                ColumnSize={ColumnSize}
                setColumnSize={setColumnSize}
            />
        </div>
    )
}
const BodyHead = ({ ColumnSize, setColumnSize, TableData, disabled }) => {

    const HeadCollection =
        TableData.columnData.map(columnInfo =>
            BodyCell({
                ColumnSize: ColumnSize,
                setColumnSize: setColumnSize,
                columnInfo: columnInfo,
                disabled: disabled,
                bHeadCell: true
            })
        )

    return (
        <div class='BodyHead'>
            {HeadCollection}
        </div>
    )
}

const TableBody = ({ ColumnSize, setColumnSize, TableData, disabled }) => {

    const BodyRows = new Set();
    for (let i = 0; i < TableData.rowIs.length; i++) {
        BodyRows.add(
            BodyRow({
                ColumnSize: ColumnSize,
                setColumnSize: setColumnSize,
                columnData: TableData.columnData,
                valueIndex: i,
                disabled: disabled
            }))
    }

    return (
        <div class='TableBody'>
            {BodyRows}
        </div>
    )
}
const BodyRow = ({ ColumnSize, setColumnSize,
    columnData, valueIndex, disabled }) => {

    const BodyCells =
        columnData.map(columnInfo =>
            BodyCell({
                ColumnSize: ColumnSize,
                setColumnSize: setColumnSize,
                columnInfo: columnInfo,
                valueIndex: valueIndex,
                disabled: disabled,
                bHeadCell: false
            })
        )

    return (
        <div class='BodyRow'>
            {BodyCells}
        </div>
    )
}
const BodyCell = ({
    ColumnSize,
    setColumnSize,
    columnInfo,
    valueIndex,
    disabled,
    bHeadCell }) => {

    let ContentComponent = null
    //если данный компонент - ячейка заголовка
    if (bHeadCell) {
        ContentComponent = <p> {columnInfo.headerName}</p>
    }
    else {//если данный компонент - основная ячейка
        ContentComponent = CellComponent(columnInfo, valueIndex, disabled)
    }

    return (
        <div class='BodyCell'>
            <div class='CellContent' >
                {ContentComponent}
            </div >
            <div class='CellSepar' />
        </div>
    )
}
const CellComponent = (columnInfo, valueIndex, disabled) => {
    let component = null;
    let comboboxData = null;

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
    ComponentData.valueObj = columnInfo.rowVals[valueIndex]
    ComponentData.disabled = disabled
    ComponentData.comboboxData = comboboxData

    return component({ ComponentData: ComponentData })
}

export const Table = () => {
    const cls = TableStyle()
    const disabled = false

    //определение ширин столбцов по умолчанию
    let DefaultColumnSize = new Map()
    TableData.columnData.forEach(q => {
        let column_w = StartTableWidth
        if (TableStartWidths.has(q.headerPropName)) {
            column_w = TableStartWidths[q.headerPropName]
        }
        DefaultColumnSize.set(q.headerPropName, column_w)
    })
    //ширина столбцов
    const [ColumnSize, setColumnSize] = useState(DefaultColumnSize)

    return (
        <div class={cls.Table}>
            <TableHead TableData={TableData} disabled={disabled} />
            <BodyContainer TableData={TableData} disabled={disabled} />
        </div>
    )
}
