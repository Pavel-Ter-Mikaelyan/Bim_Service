import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import { HeadMenuCheckBox } from './HeadMenuCheckBox';
import { HeadMenuButton } from './HeadMenuButton';
import { HeadMenuAddButton } from './HeadMenuAddButton';

//стили
const HeadMenuStyle = createUseStyles({
    HeadMenu: {
        display: 'flex',
        alignItems: 'center',
    }
})

export const HeadMenu = ({ TableInfo }) => {
    const cls = HeadMenuStyle()

    return (
        <div class={cls.HeadMenu} >
            <HeadMenuCheckBox TableInfo={TableInfo} />
            <HeadMenuButton TableInfo={TableInfo} />
            <HeadMenuAddButton TableInfo={TableInfo}/>
        </div>
    )
}