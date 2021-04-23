import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

//стили
const useStyles = createUseStyles({
    Tabs: {
        display: 'flex',
        overflow: 'hidden',
        alignSelf: 'flex-end',
        '& >div': {
            padding: '2px 10px 2px 10px',
            '&:hover': {
                background: 'rgba(150, 150, 150, 0.2)',
                cursor: 'pointer'
            }
        },
        '& >.active': {
            //fontWeight: 'bold',
            borderTop: '1px solid rgba(109, 109, 109, 0.8)',
            borderLeft: '1px solid rgba(109, 109, 109, 0.8)',
            borderRight: '1px solid rgba(109, 109, 109, 0.8)',
            borderTopLeftRadius: '8px',
            borderTopRightRadius: '8px',
        },
        '& >.notActive': {
            borderBottom: '1px solid rgba(109, 109, 109, 0.8)',
            borderTopLeftRadius: '8px',
            borderTopRightRadius: '8px',
        },
        '& >.end': {
            flexBasis: '100%'
        },
        '& >.start': {
            flexBasis: '8px',
            padding: 0
        }
    }
})

const Tab = ({ active, text, onClick, end, start }) => {
    let className = active ? 'active' : 'notActive'
    if (end) {
        className += ' end'
    }
    if (start) {
        className += ' start'
    }
    return (<div class={className} onClick={onClick}>{text}</div>)
}

export const Tabs = ({ startItem, arr, onActivateItem }) => {
    const [currItem, setCurrItem] = useState(startItem);

    const Activate = (i) => {
        setCurrItem(i)
        onActivateItem(i)
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
