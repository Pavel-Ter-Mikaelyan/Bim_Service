import React, { useState, useEffect } from 'react'
import NavPanel from '../NavPanel/NavPanel'
import { SourcePanel } from '../SourcePanel/SourcePanel'
import { useStyles } from './Styles'
import {
    NavSourcePanel_MinW,
    MainPanelMargin,
    NavPanel_StartW,
    SepPanel_W
} from '../../constants/Constants'

export function MainPanel() {
    //размеры панелей по умолчанию
    const [sizes, setSizes] = useState({
        NavPanel_W: NavPanel_StartW + 'px',
        SourcePanel_W: '1fr'
    })
    const [MD, setMD] = useState(false)

    const cls = useStyles(sizes);

    let MainPanelElem
    let NavPanelElem

    //Изменение размера панелей по событию мыши
    let h_move = e => {
        let NavPanel_W = e.pageX - NavPanelElem.offsetLeft
        let SourcePanel_W =
            MainPanelElem.offsetWidth -
            NavPanel_W -
            SepPanel_W;
        if (NavPanel_W > NavSourcePanel_MinW &&
            SourcePanel_W > NavSourcePanel_MinW) {
            setSizes({
                NavPanel_W: NavPanel_W + 'px',
                SourcePanel_W: '1fr'
            })
        }
    }
    let h_up = () => { setMD(false) }

    //Изменение размера панелей по событию изменения размеров окна
    let h_resize = () => {
        let WindowWidth = document.documentElement.clientWidth;
        let NavPanel_W = NavPanelElem.offsetWidth
        let SourcePanel_W =
            WindowWidth -
            2 * MainPanelMargin -
            SepPanel_W -
            NavPanel_W
        if (SourcePanel_W > NavSourcePanel_MinW) {
            setSizes({
                NavPanel_W: NavPanel_W + 'px',
                SourcePanel_W: '1fr'
            })
        }
        else {
            setSizes({
                NavPanel_W: '1fr',
                SourcePanel_W: (NavSourcePanel_MinW + 1) + 'px'
            })
        }
    }

    //подписка на события мыши и изменение размеров окна 
    useEffect(() => {
        MainPanelElem = document.getElementsByClassName(cls.MainPanel)[0]
        NavPanelElem = document.getElementsByClassName(cls.NavPanel)[0]
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

    return (
        <div class={cls.MainPanel}>
            <NavPanel parent_cls={cls} />
            <div class={cls.SepPanel} onMouseDown={() => setMD(!MD)} />
            <SourcePanel parent_cls={cls} />
        </div>
    );
}


