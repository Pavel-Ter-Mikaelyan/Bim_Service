import React, { useState, useEffect } from 'react';

import { BodyCell } from './BodyCell'

export const BodyHead = ({ TableInfo }) => {
    let HeadCollections = []
    const array = TableInfo.newRowMode ?
        TableInfo.TableState.NewRowTableData.TableData.columnData :
        TableInfo.TableState.MainTableData.TableData.columnData
    array.forEach((value, ColumnIndex) =>
        HeadCollections.push(
            <BodyCell
                TableInfo={TableInfo}
                ColumnIndex={ColumnIndex}
                bHeadCell={true} />
        )
    )
    return (
        <div class='BodyHead'>
            {HeadCollections}
        </div>
    )
}