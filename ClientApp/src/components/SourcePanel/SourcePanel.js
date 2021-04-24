import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';
import { Tabs } from  '../Tabs/Tabs'

const useStyles = createUseStyles({
    SourceBorder: {
       
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






