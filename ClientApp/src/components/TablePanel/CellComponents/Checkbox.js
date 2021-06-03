import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import CheckBoxOutlineBlankOutlinedIcon from '@material-ui/icons/CheckBoxOutlineBlankOutlined';
import CheckBoxOutlinedIcon from '@material-ui/icons/CheckBoxOutlined';

import { BoldLineColor, SimpleLineColor } from '../../../constants/Constants'

//стили
const CheckBoxStyle = createUseStyles({
    CheckBox: {
        display: 'flex',
        alignItems: 'center', //по центру по вертикали 
        justifyContent: 'center', //по центру по горизонтали  
        height: '100%',
        width: '100%',
        cursor: 'pointer',
        '& svg': {
            fill: disabled => disabled ?
                SimpleLineColor : BoldLineColor,
            width: 20,
            height: 20
        }
    }
})

export const Checkbox = ({ ComponentData }) => {
   
    const cls = CheckBoxStyle(ComponentData.disabled)       
    const icon =
        ComponentData.valueObj.value ?
            <CheckBoxOutlinedIcon /> :
            <CheckBoxOutlineBlankOutlinedIcon />

    const onClick = (e) => {
        ComponentData.onChange(e, 'Checkbox')
    }

    return (
        <div
            class={cls.CheckBox}
            onClick={onClick}
        >
            {icon}
        </div>
    )
}