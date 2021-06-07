import React, { useState, useEffect } from 'react';

import { BodyCell } from './BodyCell'

export const BodyRow = ({ TableInfo, RowIndex }) => {
    let BodyCells = []
    const array = TableInfo.newRowMode ?
        TableInfo.TableState.NewRowTableData.TableData.columnData :
        TableInfo.TableState.MainTableData.TableData.columnData
    array.forEach((value, ColumnIndex) =>
        BodyCells.push(
            <BodyCell TableInfo={TableInfo}
                ColumnIndex={ColumnIndex}
                bHeadCell={false}
                RowIndex={RowIndex} />
        ))

    return (
        <div class='BodyRow'>
            {BodyCells}
        </div>
    )
}