import React, { useState, useEffect } from 'react';

import { SeparIndicators } from './SeparIndicators'
import { BodyHead } from './BodyHead'
import { TableBody } from './TableBody'

export const BodyContainer = ({ TableInfo }) => {
    let overflowX
    if (TableInfo.TableState.BodyContainerOverflowX) {
        overflowX = 'auto'
    } else {
        overflowX = 'hidden'
    }

    return (
        <div class='BodyContainer' style={{ overflowX: overflowX }}>
            <SeparIndicators TableInfo={TableInfo} />
            <BodyHead TableInfo={TableInfo} />
            <TableBody TableInfo={TableInfo} />
        </div>
    )
}