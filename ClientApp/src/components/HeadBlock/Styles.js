import { createUseStyles } from 'react-jss';
import { HeadBlockHeight, Window_minW, MainPanelMargin  } from '../Constants/Constants'

export const useStyles = createUseStyles({
    HeadBlock: {
        height: HeadBlockHeight,
        padding: 0,
        margin: 0,
        display: 'flex',
        alignItems: 'center',
        minWidth: Window_minW + MainPanelMargin,

        background: 'rgba(200, 200, 200, 0.3)',
        boxShadow: '1px 1px 3px 1px rgba(0, 0, 0, 0.3)',
                
        userSelect: 'none',

        '& h2, span': {                       
            margin: '0 0 0 5px'
        },
        '& span': {
            fontSize: 36
        },
    }
})








