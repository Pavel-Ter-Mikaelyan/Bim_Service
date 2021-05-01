import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import CheckBoxOutlineBlankOutlinedIcon from '@material-ui/icons/CheckBoxOutlineBlankOutlined';
import CheckBoxOutlinedIcon from '@material-ui/icons/CheckBoxOutlined';

export const TableManagerContainer = () => {

    return (
        <div class='TableManagerContainer'>
            <CheckBoxOutlineBlankOutlinedIcon />
            <CheckBoxOutlinedIcon />
            <CheckBoxOutlinedIcon />
        </div>
    )
}