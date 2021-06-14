import { NullUndefValid } from '../constants/Constants'

//-----------------------------------------------------------------------
//конструктор для загрузки дерева
const LoadTreeNodesData_Action =
    (TreeNodesData, SelectedId, TreeDictionary) => ({
        type: 'LOAD_TREENODES',
        Data: TreeNodesData,
        TreeDictionary: TreeDictionary,
        SelectedId: SelectedId
    })
//загрузить данные узлов дерева из базы
export async function LoadTreeNodesData(dispatch, SelectedId) {
    let TreeNodesData = null
    let TreeDictionary = null
    try {
        const response1 = await fetch("/api/TreeView/GetNodes");
        if (response1.ok) {
            TreeNodesData = await response1.json();
        }
        const response2 = await fetch("/api/TreeView/GetTreeDictionary");
        if (response2.ok) {
            TreeDictionary = await response2.json();
        }
    }
    catch { return }
    if (!NullUndefValid([TreeNodesData, TreeDictionary])) {
        return
    }

    dispatch(LoadTreeNodesData_Action(
        TreeNodesData,
        SelectedId,
        TreeDictionary
    ))
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
            if (response1.ok) {
                TableData = await response1.json();
            }
        }
        catch { }
    }
    dispatch(LoadTableData_Action(TableData))
}
