import React, { useState, useEffect } from 'react';

import { Button } from '../Components/Button';
import AddBoxOutlinedIcon from '@material-ui/icons/AddBoxOutlined';

//кнопка добавления новой строки в главную таблицу
export const HeadMenuAddButton = ({ TableInfo }) => {

    //добавить новую строку в главную таблицу
    const AddNewRow = () => {
        TableInfo.TableState.MainTableData.TableData.rowIds.push('-1')
        TableInfo.TableState.MainTableData.TableData
            .columnData.forEach((columnData, i) => {
                //добавляемое значение ячейки
                let value = null
                //если главная таблица в режиме удаления,
                //то для первого столбца берется стандартное значение ячейки
                if (i == 0 && TableInfo.TableState.deleteMode) {
                    value = { value: false }
                } else {
                    //индекс столбца в таблице новых строк
                    //(в режиме удаления индекс будет меньше на 1
                    //относительно главной таблицы)
                    const NewRowIndex = TableInfo.TableState.deleteMode ? i - 1 : i
                    //значение ячейки берется из таблицы новых строк
                    value =
                        TableInfo.TableState.NewRowTableData.TableData.columnData[NewRowIndex].rowVals[0]
                }
                columnData.rowVals.push({ ...value })
            })
        //применить изменения
        TableInfo.setTableState({ ...TableInfo.TableState })
    }

    if (TableInfo.newRowMode) {
        return (
            < Button
                Icon={<AddBoxOutlinedIcon size="small" />}
                text='Добавить'
                Click={AddNewRow}
                disabled={TableInfo.TableState.disabled}
            />
        )
    } else {
        return null
    }
}