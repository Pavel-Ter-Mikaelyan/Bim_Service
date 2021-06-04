import React, { useState, useEffect } from 'react';

import { BodyCell } from './BodyCell'

export const BodyRow = ({ TableInfo, RowIndex }) => {
    let BodyCells = []
    TableInfo.TableState.MainTableData.TableData.columnData.forEach((value, ColumnIndex) =>
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