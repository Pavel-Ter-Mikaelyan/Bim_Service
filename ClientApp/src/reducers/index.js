import { combineReducers } from 'redux'
import { TreeNodes } from './TreeNodes'
import { TablePanelInfo } from './TablePanelInfo'

export const rootReducer = combineReducers({
    TreeNodes,
    TablePanelInfo
})


