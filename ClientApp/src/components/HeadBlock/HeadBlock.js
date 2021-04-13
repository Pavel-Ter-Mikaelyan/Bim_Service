import React from 'react';
import { useStyles } from './Styles'

export function HeadBlock() {
    const cls = useStyles();

    const [value, setValue] = React.useState(2);

    const handleChange = (event, newValue) => {
        setValue(newValue);
    };

    return (
        <div class={cls.HeadBlock}>
            <span class="material-icons-outlined">
                fact_check
            </span>
            <h2> BIM Servise</h2>
        </div>
    )
}
