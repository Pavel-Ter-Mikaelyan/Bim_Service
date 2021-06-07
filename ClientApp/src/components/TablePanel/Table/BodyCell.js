import React, { useState, useEffect } from 'react';

import { addSeparIndicatorInfo } from './SharedMethods/addSeparIndicatorInfo'
import { CellComponent } from './CellComponent'
import { MinTableCellWidth } from '../../../constants/Constants'

export const BodyCell = ({ TableInfo, ColumnIndex, bHeadCell, RowIndex }) => {

    const TableData =
        TableInfo.newRowMode ?
            TableInfo.TableState.NewRowTableData :
            TableInfo.TableState.MainTableData
    //ширина столбца для текущей ячейки
    let currr_W = TableData.ColumnSizeData[ColumnIndex].column_w

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
            <p> {TableData.TableData.columnData[ColumnIndex].headerName}</p>
    }
    else {//если данный компонент - основная ячейка
        ContentComponent =
            < CellComponent
                TableInfo={TableInfo}
                ColumnIndex={ColumnIndex}
                RowIndex={RowIndex}
            />
    }

    //Изменение размера ячейки по событию мыши
    let h_move = e => {
        setNewClientX(e.clientX)
        //сместить сепаратор
        let newSeparIndicator_W = startSeparIndicator_W + newClientX - oldClientX
        TableData.ColumnSizeData[ColumnIndex].SeparIndicator_W = newSeparIndicator_W
         //применить изменения
        TableInfo.setTableState({ ...TableInfo.TableState })
    }
    let h_up = () => {
        //скрыть сепаратор 
        addSeparIndicatorInfo(TableData.ColumnSizeData, false)
        //изменение ширины столбца
        setMD(false)
        const newWidth =
            Math.max(currr_W + newClientX - oldClientX, MinTableCellWidth)
        TableData.ColumnSizeData[ColumnIndex].column_w = newWidth
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
        addSeparIndicatorInfo(TableData.ColumnSizeData, true, ColumnIndex)
        //применить изменения
        TableInfo.setTableState({ ...TableInfo.TableState })
        //установить стартовое смещение сепаратора
        setStartSeparIndicator_W(TableData.ColumnSizeData[ColumnIndex].SeparIndicator_W)
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