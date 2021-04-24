import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import NavTreeView from '../NavTreeView/NavTreeView'
import NavSelectInfo from '../NavSelectInfo/NavSelectInfo'
import { LineStyle } from '../../constants/Constants'

const useStyles = createUseStyles({
    PanelWindow: {
        overflow: 'auto',
        padding: '5px 0 0 5px',
        borderTop: LineStyle
    }
})

export default function NavPanel({ parent_cls }) {
    return (
        <div class={parent_cls.NavPanel}>
            <NavSelectInfo />
            <div class={useStyles().PanelWindow} >
                <NavTreeView />
            </div >
        </div>
    );
}




