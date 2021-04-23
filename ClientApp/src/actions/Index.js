const LoadTreeNodesData_Action = (TreeNodesData, SelectedId) => ({
    type: 'LOAD_TREENODES',
    Data: TreeNodesData,
    SelectedId: SelectedId
})

export async function LoadTreeNodesData(dispatch, SelectedId) {
    const response = await fetch("/api/TreeView/GetNodes");
    const TreeNodesData = await response.json();
    dispatch(LoadTreeNodesData_Action(TreeNodesData, SelectedId))
}

