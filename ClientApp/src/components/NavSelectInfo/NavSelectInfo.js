import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux'
import { createUseStyles } from 'react-jss';

import { Focus_Icon, NullUndefValid } from '../../constants/Constants'
import { GetNode } from '../../constants/GetNode'

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
    const SelectedId = state.TreeNodes.SelectedId
    const TreeNodesData = state.TreeNodes.Data
    const TreeDictionary = state.TreeNodes.TreeDictionary 
    if (!NullUndefValid([SelectedId, TreeDictionary, TreeNodesData])) {
        return null
    }

    const currNode = GetNode(TreeNodesData, SelectedId)
    if (!NullUndefValid([currNode])) return null

    const Dict = TreeDictionary.find(Node =>
        Node.systemNodeName == currNode.systemName)
    if (!NullUndefValid([Dict])) return null

    return Dict.nodeName
}

