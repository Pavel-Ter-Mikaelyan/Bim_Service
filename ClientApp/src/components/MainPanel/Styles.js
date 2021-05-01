import { createUseStyles } from 'react-jss';
import {
    HeadBlockHeight,
    MainPanelMargin,
    SepPanel_W,
    Window_minW,
    SimpleLineStyle
} from '../../constants/Constants'

let NavAndSource = {
    display: 'grid',
    gridTemplateColumns: '1fr',
    gridTemplateRows: '2.3em 1fr',
    padding: '0 12px 12px 12px ',

    border: SimpleLineStyle,
    borderRadius: 12,
    background: 'rgba(200, 200, 200, 0.3)',
    boxShadow: '2px 2px 4px 2px rgba(0, 0, 0, 0.4)',

    overflow: 'hidden'
}

export const useStyles = createUseStyles({
    MainPanel: NavPanel_W => ({
        display: 'grid',
        gridTemplateColumns:
            NavPanel_W + 'px ' +
            SepPanel_W + 'px ' +
            '1fr',
        gridTemplateRows: '1fr',
        margin: MainPanelMargin,
        height: 'calc(100vh - ' +
            HeadBlockHeight + ' - ' +
            2 * MainPanelMargin + 'px)',
        minWidth: Window_minW,

        '& >div.SourcePanel': NavAndSource,
        '& >div.NavPanel': NavAndSource,
        '& >div.SepPanel': { cursor: 'col-resize' }
    })    
});

//ЕСЛИ НАДО БУДЕТ СКРЫВАТЬ ПАНЕЛИ
//NavPanel: Object.assign({}, NavAndSource, { display: 'none' }),
//SepPanel: Object.assign({ cursor: 'col-resize' }, { display: 'none' })





