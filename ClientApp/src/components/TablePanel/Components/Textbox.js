import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import { BoldLineColor, SimpleLineColor } from '../../../constants/Constants'

export const Textbox = ({ ComponentData }) => {
    const [text, setText] = useState(ComponentData.valueObj.value)
    //изменить текущее значение в объекте valueObj
    const onChange = (e) => {
        ComponentData.valueObj.value = e.target.value
        setText(e.target.value)
    }
    return (
        <input
            style={{
                color: ComponentData.disabled ?
                    SimpleLineColor : BoldLineColor,
                margin: '0 4px 0 4px',
                width: '100%',
                background: 'none',
                fontSize: '1em',
                textOverflow: 'ellipsis'
            }}
            type='text'
            value={text}
            disabled={ComponentData.disabled}
            onChange={onChange}
        />
    )
}
