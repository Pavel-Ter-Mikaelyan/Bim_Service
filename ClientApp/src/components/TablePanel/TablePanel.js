import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import { TableManagerContainer } from './TableManagerContainer'
import { TableNewRowContainer } from './TableNewRowContainer'
import { Table } from './Table'

//стили
const TablePanelStyles = createUseStyles({
    TablePanel: {
        '& *': { background: 'none' },
        display: 'flex',
        flexFlow: 'column nowrap',
        overflow: 'hidden',
        '& >.TableManagerContainer': {
            display: 'flex',
            alignItems: 'center',
            minHeight: 40,
        },
        '& >.TableNewRowContainer': {
            minHeight: 40
        },       
    }
})

export const TablePanel = () => {
    const cls = TablePanelStyles();

    return (
        <div class={cls.TablePanel} >
            <TableManagerContainer />
            <TableNewRowContainer />
            <Table />
        </div>
    )
}