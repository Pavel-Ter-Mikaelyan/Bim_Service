import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import { SimpleLineStyle, SelectColor2 } from '../../constants/Constants'

//стили
const useStyles = createUseStyles({
    Tabs: {
        display: 'flex',
        overflow: 'hidden',
        alignSelf: 'flex-end',
        userSelect: 'none',
        '& >div:not([class*=\'end\']):not([class*=\'start\'])': {
            padding: '2px 10px 2px 10px',
            '&:hover': {
                background: SelectColor2,
                cursor: 'pointer'
            }
        },
        '& >.active': {
            borderTop: SimpleLineStyle,
            borderLeft: SimpleLineStyle,
            borderRight: SimpleLineStyle,
            borderTopLeftRadius: '8px',
            borderTopRightRadius: '8px'
        },
        '& >.notActive': {
            borderBottom: SimpleLineStyle,
            borderTopLeftRadius: '8px',
            borderTopRightRadius: '8px',
        },
        '& >.end': {
            flexBasis: '100%'
        },
        '& >.start': {
            flexBasis: '8px',
        }
    }
})

//компонент 'вкладка'
const Tab = ({ active, text, onClick, end, start }) => {
    let className = active ? 'active' : 'notActive'
    if (end) { className += ' end' }
    if (start) { className += ' start' }
    return (<div class={className} onClick={onClick}>{text}</div>)
}

//компонент 'вкладки'
export const Tabs = ({ startItem, arr, onActivateItem }) => {
    const deffaultStartItem = startItem === undefined ? 0 : startItem 
    const [currItem, setCurrItem] = useState(deffaultStartItem);

    const Activate = (i) => {
        setCurrItem(i)
        if (onActivateItem !== undefined) { onActivateItem(i) }
    }

    return (
        <div class={useStyles().Tabs}>
            <Tab active={false} start={true} />
            {arr.map((item, i) => {
                return (
                    <Tab active={currItem === i}
                        text={item}
                        onClick={() => Activate(i)} />
                )
            })}
            <Tab active={false} end={true} />
        </div >
    )
}
