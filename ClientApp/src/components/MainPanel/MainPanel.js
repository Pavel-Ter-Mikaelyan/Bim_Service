import React, { useState, useEffect } from 'react'
import NavPanel from '../NavPanel/NavPanel'
import { SourcePanel } from '../SourcePanel/SourcePanel'
import { useStyles } from './Styles'
import {
    SourcePanel_MinW,
    NavPanel_MinW,
    MainPanelMargin,
    NavPanel_StartW,
    SepPanel_W
} from '../../constants/Constants'

export function MainPanel() {
    //проверочная ширина NavPanel
    const [ValidNavPanel_W, SetValidNavPanel_W] = useState()
    //ширина панели NavPanel
    const [NavPanel_W, setNavPanel_W] = useState(NavPanel_StartW)
    //состояние нажатия кнопки мыши
    const [MD, setMD] = useState(false)
    //ширина окна браузера
    const [WindowWidth, SetWindowWidth] =
        useState(document.documentElement.clientWidth)

    //стили
    const cls = useStyles(NavPanel_W);

    //Изменение размера панелей по событию мыши
    let h_move = e => {
        //установить проверочную ширину панели NavPanel
        SetValidNavPanel_W(ValidNavPanel_W + e.movementX)
        //найти проверочную ширину панели SourcePanel
        const ValidSourcePanel_W = WindowWidth -
            2 * MainPanelMargin -
            ValidNavPanel_W -
            SepPanel_W
        //установка размера панелей
        if (ValidNavPanel_W > NavPanel_MinW &&
            ValidSourcePanel_W > SourcePanel_MinW) {
            setNavPanel_W(ValidNavPanel_W)
        }
    }
    let h_up = () => { setMD(false) }

    //Изменение размера панелей по событию изменения размеров окна
    let h_resize = () => {
        //установить ширину окна браузера
        SetWindowWidth(document.documentElement.clientWidth)
        //найти проверочную ширину панели SourcePanel
        const ValidSourcePanel_W = WindowWidth -
            2 * MainPanelMargin -
            NavPanel_W -
            SepPanel_W
        //величина уменьшения ширины панели NavPanel
        const delta = SourcePanel_MinW - ValidSourcePanel_W
        if (delta > 0) { setNavPanel_W(NavPanel_W - delta) }
    }

    //подписка на события мыши и изменение размеров окна 
    useEffect(() => {
        window.addEventListener(`resize`, h_resize);
        if (MD) {
            window.addEventListener('mousemove', h_move)
            window.addEventListener('mouseup', h_up)
        }
        return () => {
            window.removeEventListener('mousemove', h_move)
            window.removeEventListener('mouseup', h_up)
            window.removeEventListener(`resize`, h_resize);
        }
    })

    const onMouseDown = () => {
        //установить ширину окна браузера
        SetWindowWidth(document.documentElement.clientWidth)
        setMD(!MD)//мышь нажата
        //установить проверочную ширину NavPanel
        SetValidNavPanel_W(NavPanel_W)
    }

    return (
        <div class={cls.MainPanel}>
            <NavPanel parent_cls={cls} />
            <div class={cls.SepPanel} onMouseDown={onMouseDown} />
            <SourcePanel parent_cls={cls} />
        </div>
    );
}


