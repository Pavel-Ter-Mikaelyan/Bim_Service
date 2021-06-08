export const TablePanelInfo =
    (state = {
        TableData: null
    }, action) => {
        switch (action.type) {
            case 'LOAD_TABLEDATA':               
                return ({
                    TableData: action.TableData                    
                })
            default:
                return state
        }
    }