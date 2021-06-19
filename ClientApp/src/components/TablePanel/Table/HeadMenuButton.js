import React, { useState, useEffect } from 'react';

import IndeterminateCheckBoxOutlinedIcon from '@material-ui/icons/IndeterminateCheckBoxOutlined';
import { Button } from '../Components/Button';

export const HeadMenuButton = ({ TableInfo }) => {

    const deleteMode = TableInfo.TableState.deleteMode

    //удалить строки в таблице
    const DeleteClick = () => {
        if (deleteMode == false) { return }
        TableInfo.TableState.MainTableData.TableData
            .columnData[0].rowVals.forEach((rowVal, i) => {
                if (rowVal.value == 'true') {
                    delete TableInfo.TableState.MainTableData.TableData.rowIds[i]
                    TableInfo.TableState.MainTableData.TableData
                        .columnData.forEach(columnData => {
                            delete columnData.rowVals[i]
                        })
                }
            })
        TableInfo.TableState.MainTableData.TableData
            .columnData.forEach(columnData => {
                columnData.rowVals =
                    columnData.rowVals.filter(rowVal => rowVal != undefined)
            })
        TableInfo.TableState.MainTableData.TableData.rowIds =
            TableInfo.TableState.MainTableData.TableData.rowIds
                .filter(rowId => rowId != undefined)
        //применить изменения
        TableInfo.setTableState({ ...TableInfo.TableState })
    }

    if (deleteMode && TableInfo.newRowMode == false) {
        return (
            < Button
                Icon={<IndeterminateCheckBoxOutlinedIcon size="small" />}
                text='Удалить'
                Click={DeleteClick}
                disabled={TableInfo.TableState.disabled}
            />
        )
    } else {
        return null
    }
}