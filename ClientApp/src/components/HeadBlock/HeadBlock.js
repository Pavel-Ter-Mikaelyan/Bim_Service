import React from 'react';
import { useStyles } from './Styles'

export function HeadBlock() {
    const cls = useStyles();

    return (
        <div class={cls.HeadBlock}>
            <span class="material-icons-outlined">
                fact_check
            </span>
            <h2> BIM Servise</h2>
        </div>
    )
}
