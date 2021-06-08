import { NodeIdConstructor } from '../constants/NodeIdConstructor'

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
    const response1 = await fetch("/api/TreeView/GetNodes");
    let TreeNodesData = await response1.json();
    const response2 = await fetch("/api/TreeView/GetTreeDictionary");
    const TreeDictionary = await response2.json();
    SetNodeId(TreeNodesData)
  
    dispatch(LoadTreeNodesData_Action(
        TreeNodesData,
        SelectedId,
        NodeIdDeconstructor(SelectedId),
        TreeDictionary,       
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

//конструктор для загрузки данных таблицы
const LoadTableData_Action = (TableData) => ({
    type: 'LOAD_TABLEDATA',
    TableData: TableData,  
})

//загрузка данных таблицы
export async function LoadTableData(dispatch, nodeSystemName) {
    const response1 =
        await fetch('/api/TablePanelInfo/GetTableData/' + nodeSystemName);
    const TableData = await response1.json();
    dispatch(LoadTableData_Action(TableData))
}
