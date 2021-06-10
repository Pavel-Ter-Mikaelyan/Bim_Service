
export const NodeIdConstructor = (TreeNode) => {
    //получить systemName, например, 'Stage'
    const systemName = TreeNode.systemName
    //собрать текущий идентификатор узла
    let NodeId = null;
    if (TreeNode.standartNode) {
        //например Files/true/Stage/65432
        NodeId = systemName + '/' +
            TreeNode.standartNode + '/' +
            TreeNode.parentSystemName + '/' +
            TreeNode.parentId
    } else {
        //например Stage_false_35545    
        NodeId = systemName + '/' +
            TreeNode.standartNode + '/' +
            TreeNode.id
    }
    return NodeId
}