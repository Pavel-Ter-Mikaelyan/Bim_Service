﻿import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux'
import { createUseStyles } from 'react-jss';

import { TreeDictionary, Focus_Icon } from '../../constants/Constants'

const useStyles = createUseStyles({
    NavSelectInfo: {
        display: 'flex',
        alignItems: 'center',
        overflow: 'hidden',
        background: 'rgba(0, 0, 0, 0)',
        '& svg': {
            width: 15,
            height: 15,
            minWidth: 15,
            minHeight: 15,
        },
        '& p': {
            margin: '0 0 0 5px',
            fontSize: '1em',
            //fontWeight: 'bold',
            whiteSpace: 'nowrap '           
        }
    }
})

const NavSelectInfo = ({ TreeNodesSelectedId }) => {
    //получить, например, 'Stage' из '12345_Stage'
    const arr = TreeNodesSelectedId.split('_');
    const SelectedName =
        TreeNodesSelectedId !== '-1' ?
            TreeDictionary.get(arr[1]) : '...'
    return (
        <div class={useStyles().NavSelectInfo}>
            <Focus_Icon />
            <p> {'[ ' + SelectedName + ' ]'}</p>
        </div>
    )
}

export default connect(
    state => ({ TreeNodesSelectedId: state.TreeNodes.SelectedId })
)(NavSelectInfo)