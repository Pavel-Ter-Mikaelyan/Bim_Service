import React from 'react';
import { createUseStyles } from 'react-jss';
import {
    ThemeColor1,
    ThemeColor2,
    scrollbarCollor1,
    scrollbarCollor2
} from '../../constants/Constants'
import { HeadBlock } from '../HeadBlock/HeadBlock'
import { MainPanel } from '../MainPanel/MainPanel'

const MainComponentStyles = createUseStyles({
    MainComponent: {
        background: ThemeColor1,
        overflow: 'hidden',
        '& *': {
            scrollbarColor: scrollbarCollor1 + ' ' + scrollbarCollor2
        },
        '& *::-webkit-scrollbar': {
            width: '12px',
            height: '12px',
        },
        '& *::-webkit-scrollbar-track': {
            boxShadow: 'inset 0 0 5px rgba(0,0,0,0.3)',
            borderRadius: '6px',
        },
        '& *::-webkit-scrollbar-thumb': {
            boxShadow: 'inset 0 0 5px rgba(0,0,0,0.5)',
            borderRadius: '6px',
        },
        '& *::-webkit-scrollbar-corner': {
            background: ThemeColor2
        }
    }
})

export const MainComponent = () => {
    const cls = MainComponentStyles()
    return (
        <div class={cls.MainComponent}>
            <HeadBlock />
            <MainPanel />
        </div>
    )
}

