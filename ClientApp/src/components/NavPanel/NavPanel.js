import React, { useState, useEffect } from 'react';
import SearchIcon from '@material-ui/icons/Search';
import { NavTreeview } from '../NavTreeview/NavTreeview'

export function NavPanel({ parent_cls }) {
    return (
        <div class={parent_cls.NavPanel}>
            <SearchIcon />
            <NavTreeview /> 
        </div>
    );
}


