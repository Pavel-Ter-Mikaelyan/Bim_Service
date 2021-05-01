import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import { TableCells } from './TableCells'
import {
    StartTableWidth,
    MinTableCellWidth,
    BoldLineStyle
} from '../../constants/Constants'

//стили
const TableColumnStyles = createUseStyles({
    TableColumn: {
        display: 'flex',
        '& >.TableCellsContainer': {
            overflow: 'hidden',
            //стиль для всех ячеек столбца
            '& >.TableCellsHeader, >div': {
                display: 'flex',
                alignItems: 'center', //по центру по вертикали              
                width: width => width
            },
            //стиль для ячеек заголовка
            '& >.TableCellsHeader': {
                border: BoldLineStyle,
                height: 40,
                justifyContent: 'center',//по центру по горизонтали                
                //текст заголовка столбцов
                '& >p': {
                    margin: 5,
                    userSelect: 'none', //текст не выделяется
                    overflow: 'hidden'
                }
            },
            //стиль для всех ячеек, кроме заголовка
            '& >div': {
                height: 25,
                borderBottom: BoldLineStyle,
                borderLeft: BoldLineStyle,
                borderRight: BoldLineStyle,
                '&:hover': {
                    boxShadow: '0 0 3px 2px rgba(156,117,114,0.8)'
                }
            },
            //стиль для компонента select ячейки Combobox
            '& >.Combobox >select': {
                margin: '0 0 0 4px',
                width: '100%',
                height: '100%',
                fontSize: '1em',
                cursor: 'pointer',
                textOverflow: 'ellipsis'
            },
            //стиль для компонента input ячейки Textbox           
            '& >.Textbox >input':
            {
                margin: '0 4px 0 4px',
                width: '100%',
                fontSize: '1em',
                textOverflow: 'ellipsis'
            },
            //стиль для компонента div ячейки Checkbox
            '& >.Checkbox >div':
            {
                display: 'flex',
                alignItems: 'center', //по центру по вертикали 
                justifyContent: 'center', //по центру по горизонтали  
                height: '100%',
                width: '100%',
                cursor: 'pointer',
            }
        },
        //разделитель столбцов
        '& >.ColumnSeparate': {
            width: 3,
            height: '100%',
            cursor: 'col-resize',
            background: 'rgba(156,117,114,0.8)',
            //border: '1px solid rgba(156,117,114,0.8)'
        }
    }
})

export const TableColumn = ({ columnInfo, disabled }) => {
    //ширина ячейки
    const [width, setWidth] = useState(StartTableWidth)
    //состояние нажатия кнопки мыши
    const [MD, setMD] = useState(false)
    //координаты мыши
    const [oldClientX, setOldClientX] = useState(0)
    const [newClientX, setNewClientX] = useState(0)

    const cls = TableColumnStyles(width)

    //Изменение размера ячейки по событию мыши
    let h_move = e => {
        setNewClientX(e.clientX)
    }
    let h_up = () => {
        setMD(false)
        const newWidth = width + newClientX - oldClientX
        if (newWidth > MinTableCellWidth) {
            setWidth(newWidth)
        }
        else {
            setWidth(MinTableCellWidth)
        }
        document.body.style.cursor = 'default'
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
    }

    return (
        <div class={cls.TableColumn}>
            <div class='TableCellsContainer'>
                <div class='TableCellsHeader'><p>{columnInfo.headerName}</p></div>
                <TableCells columnInfo={columnInfo} disabled={disabled} />
            </div>
            <div class='ColumnSeparate' onMouseDown={onMouseDown} />
        </div>
    )
}