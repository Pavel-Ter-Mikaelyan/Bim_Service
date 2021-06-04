import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

export const TableManagerContainer = ({ TableInfo }) => {

    const onClick = () => {
        TableInfo.TableState.disabled = !TableInfo.TableState.disabled
        //применить изменения      
        TableInfo.setTableState({ ...TableInfo.TableState })
    }

    return (
        <div class='TableManagerContainer' onClick={onClick}>
           Здесь будет вкл режима редактирования и кнопки отправки в базу
         </div>
    )
}