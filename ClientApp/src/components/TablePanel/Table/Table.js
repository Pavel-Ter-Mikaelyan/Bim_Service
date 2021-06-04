import React, { useState, useEffect } from 'react';

import { TableStyle } from './TableStyle'
import { TableHead } from './TableHead'
import { BodyContainer } from './BodyContainer'

export const Table = ({ TableInfo }) => {
      
    //стили
    const cls = TableStyle(
        {
            deleteMode: TableInfo.TableState.deleteMode,
            disabled: TableInfo.TableState.disabled
        })

    return (
        <div class={cls.Table}>
            <TableHead TableInfo={TableInfo} />
            <BodyContainer TableInfo={TableInfo} />
        </div>
    )
}
