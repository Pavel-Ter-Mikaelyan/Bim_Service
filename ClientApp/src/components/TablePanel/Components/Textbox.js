import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import { BoldLineColor, SimpleLineColor } from '../../../constants/Constants'

export const Textbox = ({ ComponentData }) => {
    //изменить текущее значение в объекте valueObj
    const onChange = (e) => {
        ComponentData.valueObj.value = e.target.value
    }
    return (
        <input
            style={{
                color: ComponentData.disabled ?
                    SimpleLineColor : BoldLineColor,
                margin: '0 4px 0 4px',
                width: '100%',
                fontSize: '1em',
                textOverflow: 'ellipsis'
            }}
            type='text'
            value={ComponentData.valueObj.value}
            disabled={ComponentData.disabled}
            onChange={onChange}
        />
    )
}
