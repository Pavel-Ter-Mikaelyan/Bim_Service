import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import NavTreeView from '../NavTreeView/NavTreeView'
import NavSelectInfo from '../NavSelectInfo/NavSelectInfo'

const useStyles = createUseStyles({
    PanelWindow: {
        overflow: 'auto',
        padding: '5px 0 0 5px',
        borderTop: '1px solid rgba(109, 109, 109, 0.8)'
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




