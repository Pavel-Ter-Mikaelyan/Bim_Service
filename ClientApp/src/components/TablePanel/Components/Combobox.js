import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import {
    BoldLineColor,
    SimpleLineColor,
} from '../../../constants/Constants'

const ComboboxStyles = createUseStyles({
    Combobox: {
        margin: '0 0 0 4px',
        width: '100%',
        height: '100%',
        background: 'none',
        fontSize: '1em',
        cursor: 'pointer',
        textOverflow: 'ellipsis',
        color: disabled => disabled ? SimpleLineColor : BoldLineColor
    }
})

export const Combobox = ({ ComponentData }) => {
    const cls = ComboboxStyles(ComponentData.disabled)

    //изменить текущее значение в объекте valueObj
    const onChange = (e) => {
        if (e !== undefined) {
            ComponentData.valueObj.value = e.target.value
        }
    }

    return (
        <select class={cls.Combobox}
            onChange={onChange}
            disabled={ComponentData.disabled}
        >
            {ComponentData.comboboxData.map(value =>
                ComponentData.valueObj.value == value ?
                    (<option selected>{value}</option>) :
                    (<option>{value}</option>)
            )}
        </select>
    )
}