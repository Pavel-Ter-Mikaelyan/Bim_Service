import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import { BoldLineColor, SimpleLineColor } from '../../../constants/Constants'

export const Textbox = ({ ComponentData }) => {

    const onChange = (e) => {
        ComponentData.onChange(e, 'Textbox')
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
            value={ComponentData.valueObj.value}
            disabled={ComponentData.disabled}
            onChange={onChange}
        />
    )
}
