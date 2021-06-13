
export const GetNode = (TreeNodesData, SelectedId) => {
    if (TreeNodesData == null) return null
    if (TreeNodesData.nodeId == SelectedId) {
        return TreeNodesData
    }
    else {
        if (Array.isArray(TreeNodesData.children)) {
            let child = null
            TreeNodesData.children
                .find(node => {                    
                    child = GetNode(node, SelectedId)                 
                    if (child != null) {
                        return true
                    }
                }
            )            
            return child
        } else {
            return null
        }
    }
}