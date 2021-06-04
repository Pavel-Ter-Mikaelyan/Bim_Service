import React, { useState, useEffect } from 'react';

import { SeparIndicators } from './SeparIndicators'
import { BodyHead } from './BodyHead'
import { TableBody } from './TableBody'

export const BodyContainer = ({ TableInfo }) => {
    return (
        <div class='BodyContainer'>
            <SeparIndicators TableInfo={TableInfo} />
            <BodyHead TableInfo={TableInfo} />
            <TableBody TableInfo={TableInfo} />
        </div>
    )
}