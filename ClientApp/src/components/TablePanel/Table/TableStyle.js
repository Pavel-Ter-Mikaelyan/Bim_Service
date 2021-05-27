import { createUseStyles } from 'react-jss';

import {
    ThemeColor1,
    ThemeColor2,
    ThemeColor3,
    SimpleLineStyle
} from '../../../constants/Constants'

//стили
export const TableStyle = createUseStyles({
    Table: {
        display: 'flex',
        flexFlow: 'column nowrap',
        overflow: 'hidden',
        height: '100%',
        '& >.TableHead': {
            display: 'flex',
            justifyContent: 'space-between',
            alignItems: 'center',
            '& >.HeadText': {
                display: 'flex',
                alignItems: 'center',
                userSelect: 'none',
            },
            '& >.HeadMenu': {
                display: 'flex',
                alignItems: 'center'
            },
        },
        '& >.BodyContainer': {
            position: 'relative',
            display: 'flex',
            flexFlow: 'column nowrap',
            alignItems: 'flex-start',
            height: '100%',
            background: ThemeColor2,
            border: SimpleLineStyle,
            borderRadius: 6,
            overflowY: 'hidden',
            '& >.BodyHead': {
                display: 'flex',
                '& >.BodyCell': {
                    display: 'flex',
                    background: ThemeColor3,
                    '& >.CellContent': {
                        display: 'flex',
                        alignItems: 'center',
                        justifyContent: 'center',
                        borderBottom: SimpleLineStyle,
                        //текст заголовка столбцов
                        '& >p': {
                            margin: 5,
                            textAlign: 'center',
                            userSelect: 'none'
                        }
                    }
                }
            },
            '& >.TableBody': {
                overflowX: 'hidden',
                overflowY: 'auto',
                height: '100%',
                '& >.BodyRow': {
                    display: 'flex',
                    '& >.BodyCell': {
                        display: 'flex',
                        background: ThemeColor3,
                        '& >.CellContent': {
                            display: 'flex',
                            alignItems: 'center',
                            height: 25,
                            borderBottom: SimpleLineStyle,
                        },
                    },
                    '&:hover': {
                        boxShadow: '0 0 2px 2px ' + ThemeColor1,
                    }
                }
            },
            '& >.SeparIndicator': {
                position: 'absolute',
                width: 3,
                height: '100%',
                cursor: 'col-resize',
                background: ThemeColor1
            }
        },
        '& .CellSepar': {
            width: 3,
            cursor: 'col-resize',
            background: ThemeColor1
        }
    }
})