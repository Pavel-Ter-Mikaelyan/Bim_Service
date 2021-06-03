import React, { useState, useEffect } from 'react';

import { BodyCell } from './BodyCell'

export const BodyHead = ({ TableInfo }) => {
    let HeadCollections = []
    TableInfo.TableState.TableData.columnData.forEach((value, ColumnIndex) =>
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