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
                    SimpleLineColor : BoldLineColor
            }}
            type='text'
            value={ComponentData.valueObj.value}
            disabled={ComponentData.disabled}
            onChange={onChange}
        />
    )
}
