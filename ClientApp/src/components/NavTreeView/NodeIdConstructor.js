
export const NodeIdConstructor = (TreeNodes) => {
    //получить systemName, например, 'Stage'
    const nodeType = TreeNodes.systemName
    //собрать текущий идентификатор узла
    let NodeId = null;
    if (TreeNodes.parentSystemName !== undefined &&
        TreeNodes.parentSystemName !== null) {
        //например StageId=65432_Files
        NodeId = TreeNodes.parentSystemName +
            'Id=' + TreeNodes.parentId + '_' +
            nodeType
    } else if (TreeNodes.id === undefined) {
        NodeId = '0_' + nodeType//например 0_Clients
    } else {
        NodeId = TreeNodes.id + '_' + nodeType//например 35545_Stage
    }
    return NodeId
}