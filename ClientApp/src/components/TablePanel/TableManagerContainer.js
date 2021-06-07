import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import { changeColumnForDelete } from './Table/SharedMethods/changeColumnForDelete';
import { CheckBox } from './Components/CheckBox';

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

    return (
        <div class='TableManagerContainer'>
            <CheckBox
                Checked={!TableInfo.TableState.disabled}
                text='Режим редактирования'
                Click={onClick}
                disabled={false}
            />            
        </div>
    )
}