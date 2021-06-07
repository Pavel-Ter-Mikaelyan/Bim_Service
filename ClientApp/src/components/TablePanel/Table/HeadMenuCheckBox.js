import React, { useState, useEffect } from 'react';

import { changeColumnForDelete } from './SharedMethods/changeColumnForDelete';
import { CheckBox } from '../Components/CheckBox';

export const HeadMenuCheckBox = ({ TableInfo }) => {
    //вкл/выкл режим удаления
    const ChangeMode = () => {      
        //изменить переменную режима удаления
        TableInfo.TableState.deleteMode = !TableInfo.TableState.deleteMode
        changeColumnForDelete(TableInfo)
    }

    if (TableInfo.newRowMode) {
        return null
    }
    else {
        return (
            <CheckBox
                Checked={TableInfo.TableState.deleteMode}
                text='Режим удаления'
                Click={ChangeMode}
                disabled={TableInfo.TableState.disabled}
            />
        )
    }
}