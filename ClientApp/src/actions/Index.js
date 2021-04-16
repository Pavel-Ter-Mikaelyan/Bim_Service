const TreeNodesAction = TreeNodes => ({
    type: 'LOAD_TREENODES',
    TreeNodes: TreeNodes
})

export async function LoadTreeNodes(dispatch) {
    const response = await fetch("/api/TreeView/GetNodes");
    const TreeNodes = await response.json();
    dispatch(TreeNodesAction(TreeNodes))
}
