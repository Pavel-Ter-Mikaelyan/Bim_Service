import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';
import { Tabs } from  '../Tabs/Tabs'

const useStyles = createUseStyles({
    SourceBorder: {
       // borderBottom: '1px solid rgba(109, 109, 109, 0.8)',
       // borderLeft: '1px solid rgba(109, 109, 109, 0.8)',
       // borderRight: '1px solid rgba(109, 109, 109, 0.8)',
    }
})

//компонент
export function SourcePanel({ parent_cls }) {

    const onActivateItem = (currItem) => {

    }

    return (
        <div class={parent_cls.SourcePanel}>
            <Tabs startItem={0}
                arr={["Просмотр", "Редактирование"]}
                onActivateItem={onActivateItem}
            />
            <div class={useStyles().SourceBorder }>

            </div>
        </div>
    );
}






