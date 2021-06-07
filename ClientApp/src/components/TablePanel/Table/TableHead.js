import React, { useState, useEffect } from 'react';

import { HeadMenu } from './HeadMenu'

export const TableHead = ({ TableInfo }) => {

    const TableData =
        TableInfo.newRowMode ?
            TableInfo.TableState.NewRowTableData.TableData :
            TableInfo.TableState.MainTableData.TableData
    
    return (
        <div class='TableHead'>
            <div class='HeadText'>
                <p>{TableData.tableName}</p>
            </div>
            <div class='HeadMenuContainer'>
                <HeadMenu TableInfo={TableInfo} />               
            </div>
        </div>
    )
}