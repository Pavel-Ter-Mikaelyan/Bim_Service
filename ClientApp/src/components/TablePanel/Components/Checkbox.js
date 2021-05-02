import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import CheckBoxOutlineBlankOutlinedIcon from '@material-ui/icons/CheckBoxOutlineBlankOutlined';
import CheckBoxOutlinedIcon from '@material-ui/icons/CheckBoxOutlined';

import { BoldLineColor, SimpleLineColor } from '../../../constants/Constants'

export const Checkbox = ({ ComponentData }) => {
    const [checked, setChecked] = useState(ComponentData.valueObj.value)
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
                fill: ComponentData.disabled ?
                    SimpleLineColor : BoldLineColor,
                width: 20,
                height: 20
            }
        }
    })
    //изменить текущее значение в объекте valueObj
    const onClick = () => {
        if (ComponentData.disabled) return;
        setChecked(!checked)
        ComponentData.valueObj.value = !ComponentData.valueObj.value
    }

    const icon =
        checked ?
            <CheckBoxOutlineBlankOutlinedIcon  /> :
            <CheckBoxOutlinedIcon  />

    return (
        <div
            class={CheckBoxStyle().CheckBox}
            onClick={onClick}
        >
            {icon}
        </div>
    )
}