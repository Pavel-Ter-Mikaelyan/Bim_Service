import { NodeIdConstructor } from '../components/NavTreeView/NodeIdConstructor'

export const TreeNodes =
    (state = { Data: null, SelectedId: '-1' }, action) => {
        switch (action.type) {
            case 'LOAD_TREENODES':
                let SelectedId = '-1'                
                if (ValidSelectId(action.Data, action.SelectedId)) {
                    SelectedId = action.SelectedId
                }
                else if (ValidSelectId(action.Data, state.SelectedId)) {
                    SelectedId = state.SelectedId
                }
                return ({
                    Data: action.Data,
                    SelectedId: SelectedId
                })
            default:
                return state
        }
    }

const ValidSelectId = (Data, SelectedId) => {
    if (SelectedId === null ||
        SelectedId === undefined) { return false }
    //идентификатор узла
    let currId = NodeIdConstructor(Data);
    if (currId === SelectedId) { return true }

    return Data.children
        .some(childrenData =>
            ValidSelectId(childrenData, SelectedId))
}
