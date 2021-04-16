import React, { useState, useEffect } from 'react';
import SearchIcon from '@material-ui/icons/Search';
import NavTreeView from '../NavTreeView/NavTreeView'

export function NavPanel({ parent_cls }) {
    return (
        <div class={parent_cls.NavPanel}>
            <SearchIcon/>
            <NavTreeView />
        </div>
    );
}



