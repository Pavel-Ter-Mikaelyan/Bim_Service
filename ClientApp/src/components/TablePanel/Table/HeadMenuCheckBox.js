import React, { useState, useEffect } from 'react';

import { changeColumnForDelete } from './changeColumnForDelete';
import { CheckBox } from '../Components/CheckBox';

export const HeadMenuCheckBox = ({ TableInfo }) => {       
    //вкл/выкл режим удаления
    const ChangeMode = () => {      
        //изменить переменную режима удаления
        TableInfo.TableState.deleteMode = !TableInfo.TableState.deleteMode
        changeColumnForDelete(TableInfo)
    }   

    return (
        <CheckBox
            bChecked={TableInfo.TableState.deleteMode}
            text='Режим удаления'
            Click={ChangeMode}
            disabled={TableInfo.TableState.disabled }
        />
    )
}