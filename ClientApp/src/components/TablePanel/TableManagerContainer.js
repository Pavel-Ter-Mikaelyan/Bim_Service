import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import SaveOutlinedIcon from '@material-ui/icons/SaveOutlined';

import { changeColumnForDelete } from './Table/SharedMethods/changeColumnForDelete';
import { CheckBox } from './Components/CheckBox';
import { Button } from './Components/Button';

export const TableManagerContainer = ({ TableInfo }) => {

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
        onClick()


       // TableInfo.TableState.MainTableData.TableData


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
                Icon={<SaveOutlinedIcon size="small"/>}
                text='Сохранить'
                Click={Save}
                disabled={TableInfo.TableState.disabled}
            />
        </div>
    )
}