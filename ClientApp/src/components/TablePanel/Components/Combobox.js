import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import {
    BoldLineColor,
    SimpleLineColor,
} from '../../../constants/Constants'

export const Combobox = ({ ComponentData }) => {

    //изменить текущее значение в объекте valueObj
    const onChange = (e) => {
        if (e !== undefined) {
            ComponentData.valueObj.value = e.target.value
        }
    }

    return (
        <select
            style={{
                color: ComponentData.disabled ?
                    SimpleLineColor : BoldLineColor
            }}
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