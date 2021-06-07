import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';
import {
    BoldLineColor,
    SimpleLineColor,
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
            transform: disabled => disabled ?
                null : 'translateY(2px)'
        },
        '& svg': {
            fill: disabled => disabled ?
                SimpleLineColor : BoldLineColor,
        },
        '& p': {
            color: disabled => disabled ?
                SimpleLineColor : BoldLineColor,
        }
    }
})

export const Button = ({ Id, Icon, text, Click, disabled }) => {
    const cls = ButtonStyle(disabled)

    const onClick = () => {
        if (disabled) { return }  
        Click(Id)
    }

    return (
        <div class={cls.Button} onClick={onClick} >
            {Icon}
            <p>{text}</p>
        </div>
    )
}
