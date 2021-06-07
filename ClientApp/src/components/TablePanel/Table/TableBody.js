import React, { useState, useEffect } from 'react';

import { BodyRow } from './BodyRow'

export const TableBody = ({ TableInfo }) => {
    let BodyRows = [];
    const array = TableInfo.newRowMode ?
        TableInfo.TableState.NewRowTableData.TableData.rowIds :
        TableInfo.TableState.MainTableData.TableData.rowIds

    array.forEach((val, RowIndex) => {
        BodyRows.push(
            <BodyRow
                TableInfo={TableInfo}
                RowIndex={RowIndex} />
        )
    })
    return (
        <div class='TableBody'>
            {BodyRows}
        </div>
    )
}