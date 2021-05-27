import React, { useState, useEffect } from 'react';

import { BodyRow } from './BodyRow'

export const TableBody = (TableInfo) => {
    let BodyRows = [];
    TableInfo.TableState.TableData.rowIs.forEach((val, RowIndex) => {
        BodyRows.push(BodyRow(TableInfo, RowIndex))
    })
    return (
        <div class='TableBody'>
            {BodyRows}
        </div>
    )
}