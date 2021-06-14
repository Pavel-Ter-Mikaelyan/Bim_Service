import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import SaveOutlinedIcon from '@material-ui/icons/SaveOutlined';

import { changeColumnForDelete } from './Table/SharedMethods/changeColumnForDelete';
import { CheckBox } from './Components/CheckBox';
import { Button } from './Components/Button';

export const TableManagerContainer = ({
    TableInfo,
    LoadTableData,
    LoadTreeNodesData
}) => {
    //вкл/выкл режим редактирования
    const onClick = () => {
        TableInfo.TableState.disabled = !TableInfo.TableState.disabled
        if (TableInfo.TableState.disabled && TableInfo.TableState.deleteMode) {
            TableInfo.TableState.deleteMode = false
            changeColumnForDelete(TableInfo)
        }
        //применить изменения      
        TableInfo.setTableState({ ...TableInfo.TableState })
    }
    //сохранить изменения в базе
    const Save = () => {
        //вкл/выкл режим редактирования
        onClick()
        //сохранить изменения в базе и перезагрузить дерево и таблицу
        PutTableData(TableInfo, LoadTableData, LoadTreeNodesData)
    }

    return (
        <div class='TableManagerContainer'>
            <CheckBox
                Checked={!TableInfo.TableState.disabled}
                text='Режим редактирования'
                Click={onClick}
                disabled={false}
            />
            < Button
                Icon={<SaveOutlinedIcon size="small" />}
                text='Сохранить'
                Click={Save}
                disabled={TableInfo.TableState.disabled}
            />
        </div>
    )
}

//сохранить изменения в базе и перезагрузить дерево и таблицу
async function PutTableData(
    TableInfo,
    LoadTableData,
    LoadTreeNodesData) {

    const TableData = TableInfo.TableState.MainTableData.TableData
    const SelectedId = TableData.selectedId
    let resultText = 'Не успешная запись в базу'

    try {
        let response = await fetch('/api/TablePanelInfo/PutTableData', {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(TableData)
        });
        if (response.ok) {
            const bResponse = await response.json();
            if (bResponse) {
                resultText = 'Успешная запись в базу'

                //загрузка дерева и передача Id выделенного узла
                LoadTreeNodesData(SelectedId)
                //загрузка таблицы и передача Id выделенного узла
                LoadTableData(SelectedId)
            }
        }
        else {
            resultText = 'Не успешная запись в базу, статус: ' + response.statusText;
        }
    }
    catch { }

    //сообщение в конце
    alert(resultText)
}