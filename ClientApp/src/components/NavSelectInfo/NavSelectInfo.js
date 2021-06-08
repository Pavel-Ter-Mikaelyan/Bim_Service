import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux'
import { createUseStyles } from 'react-jss';

import { Focus_Icon } from '../../constants/Constants'

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
const NavSelectInfo = ({ nodeName }) => {

    let selectedName = '...'
    if (nodeName != null) selectedName = nodeName

    return (
        <div class={useStyles().NavSelectInfo}>
            <Focus_Icon />
            <p> {'[ ' + selectedName + ' ]'}</p>
        </div>
    )
}

//присоединить состояние
const mapStateToProps = (state) => ({ nodeName: GetNodeName(state) })
export default connect(mapStateToProps)(NavSelectInfo)
//получить имя узла
const GetNodeName = (state) => {
    let SelectedId = state.TreeNodes.SelectedId
    if (SelectedId == null) return null
    let systemName = state.TreeNodes.SelectedNode.systemName
    let TreeDictionary = state.TreeNodes.TreeDictionary
    return TreeDictionary.find(Node =>
        Node.systemNodeName == systemName).nodeName
}
