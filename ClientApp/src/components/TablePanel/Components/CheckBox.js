import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import CheckBoxOutlineBlankOutlinedIcon from '@material-ui/icons/CheckBoxOutlineBlankOutlined';
import CheckBoxOutlinedIcon from '@material-ui/icons/CheckBoxOutlined';

import {
    BoldLineColor,
    SimpleLineColor,
    SelectColor2
} from '../../../constants/Constants'

const CheckBoxStyle = createUseStyles({
    CheckBox: {
        display: 'flex',
        alignItems: 'center',
        userSelect: 'none',
        padding: '2px 7px 2px 5px',
        '&:hover': {
            background: SelectColor2,
            cursor: 'pointer',
            borderRadius: 6,
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

export const CheckBox = ({ Id, bChecked, text, Click, disabled }) => {
    const cls = CheckBoxStyle(disabled)
    const [Checked, SetChecked] = useState(bChecked);

    const onClick = () => {
        if (disabled) { return }
        SetChecked(!Checked)
        Click({ Id: Id, Checked: Checked })
    }

    const icon =
        Checked ?
            <CheckBoxOutlinedIcon /> :
            <CheckBoxOutlineBlankOutlinedIcon />

    return (
        <div class={cls.CheckBox} onClick={onClick} >
            {icon}
            <p>{text}</p>
        </div>
    )
}
