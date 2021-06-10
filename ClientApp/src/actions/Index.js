import { NodeIdConstructor } from '../constants/NodeIdConstructor'
import { NodeIdDeconstructor } from '../constants/NodeIdDeconstructor'
import { NullUndefValid } from '../constants/Constants'

//-----------------------------------------------------------------------
//конструктор для загрузки дерева
const LoadTreeNodesData_Action =
    (TreeNodesData, SelectedId, SelectedNode, TreeDictionary) => ({
        type: 'LOAD_TREENODES',
        Data: TreeNodesData,
        TreeDictionary: TreeDictionary,
        SelectedId: SelectedId,
        SelectedNode: SelectedNode
    })
//загрузить данные узлов дерева из базы
export async function LoadTreeNodesData(dispatch, SelectedId) {
    let TreeNodesData = null
    let TreeDictionary = null
    try {
        const response1 = await fetch("/api/TreeView/GetNodes");
        TreeNodesData = await response1.json();
        const response2 = await fetch("/api/TreeView/GetTreeDictionary");
        TreeDictionary = await response2.json();
    }
    catch { return }
    if (!NullUndefValid([TreeNodesData, TreeDictionary])){
        return
    }
    SetNodeId(TreeNodesData)
    let SelectedNode = SelectedId != null ?
        NodeIdDeconstructor(SelectedId) : null
    dispatch(LoadTreeNodesData_Action(
        TreeNodesData,
        SelectedId,
        SelectedNode,
        TreeDictionary
    ))
}
//установить идентификатор для всех узлов
const SetNodeId = (NodesData) => {
    //идентификатор узла  
    NodesData.NodeId = NodeIdConstructor(NodesData)

    return NodesData.children
        .some(childrenData =>
            SetNodeId(childrenData))
}

//-----------------------------------------------------------------------
//конструктор для загрузки данных таблицы
const LoadTableData_Action = (TableData) => ({
    type: 'LOAD_TABLEDATA',
    TableData: TableData,
})
//загрузка данных таблицы
export async function LoadTableData(dispatch, SelectedId) {
    let TableData = null
    if (SelectedId != null) {
        try {
            const response1 =
                await fetch('/api/TablePanelInfo/GetTableData/' + SelectedId);
            TableData = await response1.json();
        }
        catch { }
    }
    dispatch(LoadTableData_Action(TableData))
}
