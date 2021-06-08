
export const NodeIdDeconstructor = (NodeId) => {
    const arr = NodeId.split('_')
    let TreeNode = {
        systemName: arr[0],
        standartNode: arr[1]
    }
    if (arr[1] == 'true') {
        TreeNode.parentSystemName = arr[2]
        TreeNode.parentId = arr[3]
    }
    else {
        TreeNode.id = arr[2]
    }

    return TreeNode
}