import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import { TableManagerContainer } from './TableManagerContainer'
import { TableNewRowContainer } from './TableNewRowContainer'
import { TableContainer } from './TableContainer'

//стили
const TablePanelStyles = createUseStyles({
    TablePanel: {
        '& *': { background: 'none' },
        display: 'flex',
        flexFlow: 'column nowrap',
        overflow: 'auto',
        '& >div.TableManagerContainer': {
            display: 'flex',
            alignItems: 'center',
            minHeight: 40,
        },
        '& >div.TableNewRowContainer': {
            minHeight: 40
        },
        '& >div.TableContainer': {
            overflow: 'auto', 
            height:'100%'
        }
    }
})

export const TablePanel = () => {
    const cls = TablePanelStyles();

    return (
        <div class={cls.TablePanel} >
            <TableManagerContainer />
            <TableNewRowContainer />
            <TableContainer />
        </div>
    )
}