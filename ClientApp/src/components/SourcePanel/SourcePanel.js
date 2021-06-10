import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import TablePanel from '../TablePanel/TablePanel'
import { Tabs } from '../Tabs/Tabs'

//компонент
export function SourcePanel() {
    return (
        <div class='SourcePanel'>
            <Tabs arr={["Редактирование"]}/>
            <TablePanel />
        </div >
    );
}

