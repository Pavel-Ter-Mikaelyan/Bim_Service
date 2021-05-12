import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux'
import { createUseStyles } from 'react-jss';

import { TreeDictionary, Focus_Icon } from '../../constants/Constants'

//стили
const useStyles = createUseStyles({
    NavSelectInfo: {
        display: 'flex',
        alignItems: 'flex-end',
        overflow: 'hidden',        
        background: 'rgba(0, 0, 0, 0)',
        '& svg': {
            margin: '0 0 6px 0',
            width: 15,
            height: 15,
            minWidth: 15,
            minHeight: 15
        },
        '& p': {
            margin: '0 0 4px 5px',
            fontSize: '1em',            
            whiteSpace: 'nowrap '           
        }
    }
})

//компонент 'панель сверху дерева'
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