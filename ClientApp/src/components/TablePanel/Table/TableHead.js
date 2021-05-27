import React, { useState, useEffect } from 'react';
import CheckBoxOutlinedIcon from '@material-ui/icons/CheckBoxOutlined';

export const TableHead = (TableInfo) => {
    return (
        <div class='TableHead'>
            <div class='HeadText'>
                <p>{TableInfo.TableState.TableData.tableName}</p>
            </div>
            <div class='HeadMenu'>               
                <p>здесь доп. инструменты </p>
            </div>
        </div>
    )
}