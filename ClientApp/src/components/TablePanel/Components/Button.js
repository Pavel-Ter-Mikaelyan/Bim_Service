import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';
import {
    SelectColor2
} from '../../../constants/Constants'

const ButtonStyle = createUseStyles({
    Button: {
        display: 'flex',
        alignItems: 'center',
        userSelect: 'none',
        padding: '2px 7px 2px 5px',
        '&:hover': {
            background: SelectColor2,
            cursor: 'pointer',
            borderRadius: 6,
        },
        '&:active': {            
            transform: 'translateY(2px)'
        }
    }
})

export const Button = ({ Id, Icon, text, Click }) => {
    const cls = ButtonStyle()

    const onClick = () => {
        Click(Id)
    }

    return (
        <div class={cls.Button} onClick={onClick} >
            {Icon}
            <p>{text}</p>
        </div>
    )
}
