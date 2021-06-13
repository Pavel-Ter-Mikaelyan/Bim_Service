export const TreeNodes =
    (state = {
        Data: null,
        TreeDictionary: null,
        SelectedId: null     
    }, action) => {
        switch (action.type) {
            case 'LOAD_TREENODES':
                let SelectedId = null
                if (ValidSelectId(action.Data, action.SelectedId)) {
                    SelectedId = action.SelectedId
                }
                else if (ValidSelectId(action.Data, state.SelectedId)) {
                    SelectedId = state.SelectedId
                }
                return ({
                    Data: action.Data,
                    SelectedId: SelectedId,                    
                    TreeDictionary: action.TreeDictionary
                })
            default:
                return state
        }
    }

const ValidSelectId = (Data, SelectedId) => {
    if (SelectedId == null) { return false }
    //идентификатор узла  
    if (Data.nodeId === SelectedId) { return true }

    return Data.children
        .some(childrenData =>
            ValidSelectId(childrenData, SelectedId))
}
