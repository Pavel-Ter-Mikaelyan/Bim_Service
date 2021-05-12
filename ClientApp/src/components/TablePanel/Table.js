import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import CheckBoxOutlinedIcon from '@material-ui/icons/CheckBoxOutlined';

import { Checkbox } from './Components/Checkbox';
import { Combobox } from './Components/Combobox';
import { Textbox } from './Components/Textbox';

import {
    ThemeColor1,
    ThemeColor2,
    ThemeColor3,
    TableStartWidths,
    StartTableWidth,
    MinTableCellWidth,
    BoldLineStyle,
    SimpleLineStyle
} from '../../constants/Constants'

const TableData = {
    tableName: 'Таблица Таблица Таблица',
    rowIs: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
    columnData: [
        {
            type: '0',
            headerName: 'Столбец 2',
            headerPropName: 'prop2',
            defVal: 'знач. по умолч.',
            rowVals: [{ value: 'знач1rgieonr;oirtnh;trdhn;dfthnft;ohidnfthoin;hiodtf' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач2' }, { value: 'знач3' }]
        },
        {
            type: 1,
            headerName: 'Столбец 1 Столбец 1 Столбец 1',
            headerPropName: 'prop1',
            defVal: 5,
            comboboxData: [1, 2, 3, 4, 5, 6, 7, 8, 9, '9ykygklhlhlufyklfuhluglguluhlugl'],
            rowVals: [{ value: '9ykygklhlhlufyklfuhluglguluhlugl' }, { value: '9' }, { value: '9' }, { value: '9' }, { value: '9' }, { value: '9' }, { value: '9' }, { value: '9' }, { value: '1' }, { value: '3' }]
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
            position: 'relative',
            display: 'flex',
            flexFlow: 'column nowrap',
            alignItems: 'flex-start',
            height: '100%',
            background: ThemeColor2,              
            border: SimpleLineStyle,
            borderRadius: 6,
            overflowY: 'hidden',
            '& >.BodyHead': {
                display: 'flex',
                '& >.BodyCell': {
                    display: 'flex',
                    background: ThemeColor3,
                    '& >.CellContent': {
                        display: 'flex',
                        alignItems: 'center',
                        justifyContent: 'center',
                        borderBottom: SimpleLineStyle,
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
                        background: ThemeColor3,
                        '& >.CellContent': {
                            display: 'flex',
                            alignItems: 'center',
                            height: 25,
                            borderBottom: SimpleLineStyle,
                        },
                    },
                    '&:hover': {
                        boxShadow: '0 0 2px 2px ' + ThemeColor1,
                    }
                }
            },
            '& >.SeparIndicator': {
                position: 'absolute',
                width: 3,
                height: '100%',
                cursor: 'col-resize',               
                background: ThemeColor1
            }
        },
        '& .CellSepar': {
            width: 3,
            cursor: 'col-resize',        
            background: ThemeColor1
        }
    }
})

const TableHead = (TableInfo) => {

    return (
        <div class='TableHead'>
            <div class='HeadText'>
                <p>{TableInfo.TableState.TableData.tableName}</p>
            </div>
            <div class='HeadMenu'>
                <CheckBoxOutlinedIcon />
                <p>Удаление </p>
            </div>
        </div>
    )
}
const SeparIndicator = (SeparIndicator_W, SeparIndicatorDisplay) => {
    return (
        <div class='SeparIndicator'
            style={{
                left: SeparIndicator_W,
                display: SeparIndicatorDisplay
            }}
        />
    )
}
const SeparIndicators = (TableInfo) => {
    return (
        TableInfo.TableState.ColumnSizeData.map(SizeData =>
            SeparIndicator(SizeData.SeparIndicator_W, SizeData.SeparIndicatorDisplay)
        )
    )
}
const BodyContainer = (TableInfo) => {
    let overflowX
    if (TableInfo.TableState.BodyContainerOverflowX) {
        overflowX = 'auto'
    } else {
        overflowX = 'hidden'
    }

    return (
        <div class='BodyContainer' style={{ overflowX: overflowX }}>
            {SeparIndicators(TableInfo)}
            {BodyHead(TableInfo)}
            {TableBody(TableInfo)}
        </div>
    )
}
const BodyHead = (TableInfo) => {
    let HeadCollections = []
    TableInfo.TableState.TableData.columnData.forEach((value, ColumnIndex) =>
        HeadCollections.push(BodyCell(TableInfo, ColumnIndex, true))
    )
    return (
        <div class='BodyHead'>
            {HeadCollections}
        </div>
    )
}
const TableBody = (TableInfo) => {
    let BodyRows = [];
    TableInfo.TableState.TableData.rowIs.forEach((val, RowIndex) => {
        BodyRows.push(BodyRow(TableInfo, RowIndex))
    })
    return (
        <div class='TableBody'>
            {BodyRows}
        </div>
    )
}
const BodyRow = (TableInfo, RowIndex) => {
    let BodyCells = []
    TableInfo.TableState.TableData.columnData.forEach((value, ColumnIndex) =>
        BodyCells.push(BodyCell(TableInfo, ColumnIndex, false, RowIndex)))
    return (
        <div class='BodyRow'>
            {BodyCells}
        </div>
    )
}
const BodyCell = (TableInfo, ColumnIndex, bHeadCell, RowIndex) => {

    //ширина столбца для текущей ячейки
    let currr_W = TableInfo.TableState.ColumnSizeData[ColumnIndex].column_w

    //состояние нажатия кнопки мыши
    const [MD, setMD] = useState(false)
    //координаты мыши
    const [oldClientX, setOldClientX] = useState(0)
    const [newClientX, setNewClientX] = useState(0)
    //стартовое смещение сепаратора
    const [startSeparIndicator_W, setStartSeparIndicator_W] = useState(0)

    let ContentComponent = null
    //если данный компонент - ячейка заголовка
    if (bHeadCell) {
        ContentComponent =
            <p> {TableInfo.TableState.TableData.columnData[ColumnIndex].headerName}</p>
    }
    else {//если данный компонент - основная ячейка
        ContentComponent =
            CellComponent(TableInfo, ColumnIndex, RowIndex)
    }

    //Изменение размера ячейки по событию мыши
    let h_move = e => {
        setNewClientX(e.clientX)
        //сместить сепаратор
        let newSeparIndicator_W = startSeparIndicator_W + newClientX - oldClientX
        TableInfo.TableState.ColumnSizeData[ColumnIndex].SeparIndicator_W = newSeparIndicator_W
        TableInfo.setTableState({ ...TableInfo.TableState })
    }
    let h_up = () => {
        //скрыть сепаратор 
        addSeparIndicatorInfo(TableInfo.TableState.ColumnSizeData, false)
        //отобразить полосу прокрутки
        TableInfo.TableState.BodyContainerOverflowX = true
        //изменение ширины столбца
        setMD(false)
        const newWidth =
            Math.max(currr_W + newClientX - oldClientX, MinTableCellWidth)
        TableInfo.TableState.ColumnSizeData[ColumnIndex].column_w = newWidth
        document.body.style.cursor = 'default'
        //применить изменения
        TableInfo.setTableState({ ...TableInfo.TableState })
    }
    //подписка на события мыши и изменение размеров окна 
    useEffect(() => {
        if (MD) {
            window.addEventListener('mousemove', h_move)
            window.addEventListener('mouseup', h_up)
        }
        return () => {
            window.removeEventListener('mousemove', h_move)
            window.removeEventListener('mouseup', h_up)
        }
    })
    const onMouseDown = (e) => {
        setMD(!MD)//мышь нажата
        //установить координаты мыши
        setOldClientX(e.clientX)
        setNewClientX(e.clientX)
        document.body.style.cursor = 'col-resize'
        //установить смещение сепаратора в соответствии с текущей шириной столбцов
        //и видимость сепаратора
        addSeparIndicatorInfo(TableInfo.TableState.ColumnSizeData, true, ColumnIndex)
        //скрыть полосу прокрутки на момент перемещения сепаратора
        //ПОКА НЕ ИСПОЛЬЗУЮ, ПОЭТОМУ true 
        TableInfo.TableState.BodyContainerOverflowX = true
        //применить изменения
        TableInfo.setTableState({ ...TableInfo.TableState })
        //установить стартовое смещение сепаратора
        setStartSeparIndicator_W(TableInfo.TableState.ColumnSizeData[ColumnIndex].SeparIndicator_W)
    }
    return (
        <div class='BodyCell'>
            <div class='CellContent' style={{ width: currr_W }} >
                {ContentComponent}
            </div >
            <div class='CellSepar' onMouseDown={onMouseDown} >
            </div>
        </div>
    )
}
const CellComponent = (TableInfo, ColumnIndex, RowIndex) => {
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
const addSeparIndicatorInfo = (ColumnSizeData, showSeparIndicator, ColumnIndex) => {

    let SeparIndicator_W = 0
    ColumnSizeData.forEach((SizeData, i) => {
        //определение смещения сепаратора
        if (SeparIndicator_W != 0) SeparIndicator_W += 3
        SeparIndicator_W += SizeData.column_w
        SizeData.SeparIndicator_W = SeparIndicator_W
        //видимость сепаратора       
        if (showSeparIndicator && ColumnIndex == i) {
            SizeData.SeparIndicatorDisplay = 'block'
        }
        else {
            SizeData.SeparIndicatorDisplay = 'none'
        }
    })
}

export const Table = () => {
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
