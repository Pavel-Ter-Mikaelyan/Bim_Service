import { createUseStyles } from 'react-jss';
import {
    HeadBlockHeight,
    MainPanelMargin,
    SepPanel_W,
    Window_minW
} from '../Constants/Constants'

let NavAndSource = {
    display: 'grid',
    gridTemplateColumns: '1fr',
    gridTemplateRows: '2em 1fr',
    padding: 10,

    border: '0.1vh solid rgba(109, 109, 109, 0.8)',
    borderRadius: 10,
    background: 'rgba(200, 200, 200, 0.3)',
    boxShadow: '2px 2px 4px 2px rgba(0, 0, 0, 0.4)',

    overflow: 'auto'
}

export const useStyles = createUseStyles({
    MainPanel: data => ({
        display: 'grid',
        gridTemplateColumns:
            data.NavPanel_W + ' ' +
            SepPanel_W + 'px ' +
            data.SourcePanel_W,
        gridTemplateRows: '1fr',
        margin: MainPanelMargin,
        height: 'calc(100vh - ' +
            HeadBlockHeight + ' - ' +
            2 * MainPanelMargin + 'px)',
        minWidth: Window_minW
    }),
    SourcePanel: NavAndSource,
    NavPanel: NavAndSource,
    SepPanel: { cursor: 'col-resize' }
});







