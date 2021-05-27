import { NodeIdConstructor } from '../constants/NodeIdConstructor'

const LoadTreeNodesData_Action = (TreeNodesData, SelectedId) => ({
    type: 'LOAD_TREENODES',
    Data: TreeNodesData,
    SelectedId: SelectedId
})

export async function LoadTreeNodesData(dispatch, SelectedId) {
    const response = await fetch("/api/TreeView/GetNodes");
    let TreeNodesData = await response.json();
    SetNodeId(TreeNodesData)
    dispatch(LoadTreeNodesData_Action(TreeNodesData, SelectedId))
}

//установить идентификатор для всех узлов
const SetNodeId = (NodesData) => {
    //идентификатор узла  
    NodesData.NodeId = NodeIdConstructor(NodesData)

    return NodesData.children
        .some(childrenData =>
            SetNodeId(childrenData))
}
