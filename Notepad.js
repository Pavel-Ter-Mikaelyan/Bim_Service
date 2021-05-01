import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import Select from 'react-select';

import {
    BoldLineColor,
    SelectColor1,
    SelectColor2,
    TransparentColor
} from '../../../constants/Constants'

//стили
const ComboboxStyles = {
    //стиль общего контейнера
    container: (provided, state) => ({
        ...provided,
        width: '100%'
    }),
    valueContainer: (provided, state) => ({
        ...provided,
        padding: 0
    }),
    //стиль одного пункта выпадающего меню
    option: (provided, state) => ({
        ...provided,
        cursor: 'pointer',
        padding: '2px 4px 2px 4px',
        background: state.isSelected ? SelectColor1 :
            state.isFocused ? SelectColor2 : TransparentColor
    }),
    //стиль контролла
    control: (provided, state) => ({
        display: 'flex',
        userSelect: 'none',
        cursor: 'pointer'
    }),
    //стиль контейнера выпадающего меню
    menuList: (provided, state) => ({
        ...provided,
        maxHeight: 200
    }),
    //стиль стрелки справа
    indicatorsContainer: (provided, state) => ({
        ...provided,
        '& svg': { fill: BoldLineColor }
    }),
    //стиль палочки справа
    indicatorSeparator: (provided, state) => ({
        ...provided,
        backgroundColor: BoldLineColor
    })
}

export const Combobox = ({ ComponentData }) => {

    //трансформация в объект, принимаемый компонентом Select
    const defaultValue = {
        value: ComponentData.valueObj.value,
        label: ComponentData.valueObj.value
    }
    //трансформация в объект, принимаемый компонентом Select
    const Options =
        ComponentData.comboboxData.map(q => ({ value: q, label: q }))
    //изменить текущее значение в объекте valueObj
    const onChange = (e) => {
        if (e !== undefined) {
            ComponentData.valueObj.value = e.value
        }
    }

    //return (
    //    <Select
    //        defaultValue={defaultValue}
    //        onChange={onChange}
    //        options={Options}
    //        styles={ComboboxStyles}
    //        isDisabled={ComponentData.disabled}
    //    />
    //)
    return (
        <select style={{
            width: '100%',
            cursor: 'pointer'
        }}>
            {ComponentData.comboboxData.map(value =>
                ComponentData.valueObj.value == value ?
                    (<option selected>{value}</option>) :
                    (<option>{value}</option>)
            )
            }
        </select>
    )
}