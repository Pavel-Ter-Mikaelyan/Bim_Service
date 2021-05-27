import React, { useState, useEffect } from 'react';

import { BodyCell } from './BodyCell'

export const BodyRow = (TableInfo, RowIndex) => {
    let BodyCells = []
    TableInfo.TableState.TableData.columnData.forEach((value, ColumnIndex) =>
        BodyCells.push(BodyCell(TableInfo, ColumnIndex, false, RowIndex)))
    return (
        <div class='BodyRow'>
            {BodyCells}
        </div>
    )
}