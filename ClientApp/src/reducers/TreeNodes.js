export const TreeNodes = (state = null, action) => {
    switch (action.type) {
        case 'LOAD_TREENODES':
            return action.TreeNodes
        default:
            return state
    }
}
