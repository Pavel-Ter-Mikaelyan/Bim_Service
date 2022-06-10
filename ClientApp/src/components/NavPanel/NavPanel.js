import React, { useState, useEffect } from 'react';

import NavTreeView from '../NavTreeView/NavTreeView'
import NavSelectInfo from '../NavSelectInfo/NavSelectInfo'

export default function NavPanel() {
    return (
        <div class='NavPanel'>          
            <NavSelectInfo/>
            <NavTreeView />
        </div>
    );
}




