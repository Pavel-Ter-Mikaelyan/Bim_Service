
export const NodeIdConstructor = (TreeNode) => {
    //получить systemName, например, 'Stage'
    const systemName = TreeNode.systemName
    //собрать текущий идентификатор узла
    let NodeId = null;
    if (TreeNode.standartNode) {
        //например Files_true_Stage_65432
        NodeId = systemName + '_' +
            TreeNode.standartNode + '_' +
            TreeNode.parentSystemName + '_' +
            TreeNode.parentId
    } else {
        //например Stage_false_35545    
        NodeId = systemName + '_' +
            TreeNode.standartNode + '_' +
            TreeNode.id
    }
    return NodeId
}