import React, { useState, useEffect } from 'react';

import { HeadMenu } from './HeadMenu'

export const TableHead = (TableInfo) => {
    return (
        <div class='TableHead'>
            <div class='HeadText'>
                <p>{TableInfo.TableState.TableData.tableName}</p>
            </div>
            <div class='HeadMenuContainer'>
                <HeadMenu />
            </div>
        </div>
    )
}