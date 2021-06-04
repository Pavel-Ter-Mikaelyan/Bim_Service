import React, { useState, useEffect } from 'react';

import { BodyRow } from './BodyRow'

export const TableBody = ({ TableInfo }) => {
    let BodyRows = [];
    TableInfo.TableState.MainTableData.TableData.rowIds.forEach((val, RowIndex) => {
        BodyRows.push(
            <BodyRow
                TableInfo={TableInfo}
                RowIndex={RowIndex}/>
        )
    })
    return (
        <div class='TableBody'>
            {BodyRows}
        </div>
    )
}