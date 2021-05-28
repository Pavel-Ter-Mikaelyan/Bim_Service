import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import DeleteIcon from '@material-ui/icons/Delete';

import { Button } from '../Components/Button';

const HeadMenuStyle = createUseStyles({
    HeadMenu: {
        display: 'flex',
        alignItems: 'center',
    }
})

export const HeadMenu = () => {
    const cls = HeadMenuStyle()

    const ButtonClick = () => {

    }

    return (
        <div class={cls.HeadMenu} >
            <Button
                Icon={<DeleteIcon size="small" />}
                text='Очистить'
                Click={ButtonClick}
            />
        </div>
    )
}