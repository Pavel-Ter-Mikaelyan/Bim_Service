import React, { useState, useEffect } from 'react';
import { useStyles } from './Styles'

import { withStyles } from '@material-ui/core/styles';
import TreeView from '@material-ui/lab/TreeView';
import TreeItem from '@material-ui/lab/TreeItem';

//иконки
import {
    Stage_Icon, Templates_Icon, Client_Icon, Template_Icon,
    Plugin_Icon, Checking_Icon, Setting_Icon, Files_Icon, File_Icon
} from '../Icons/Icons';
import AddBoxOutlinedIcon from '@material-ui/icons/AddBoxOutlined';
import IndeterminateCheckBoxOutlinedIcon from '@material-ui/icons/IndeterminateCheckBoxOutlined';
import HomeWorkOutlinedIcon from '@material-ui/icons/HomeWorkOutlined';

//стили
const StyledTreeItem = withStyles(() => ({
    iconContainer: {
        '& .minus, .plus': {
            width: 16,
            height: 16
        },
        '& .minus, .plus': { opacity: 0.6 },
        margin: 0
    },
    content: {
        margin: '0 0 2px 0'
    },
    group: {
        paddingLeft: 13,
        marginLeft: 7,
        borderLeft: `1px dashed rgba(0, 0, 0, 0.2)`
    },
    label: {
        whiteSpace: 'nowrap',
        userSelect: 'none',
        padding: 0,
        '& > div': {
            display: 'flex',
            alignItems: 'center'
        },
        '& .client, .object, .files, .file, .stage, .templates, .template, .plugin, .checking, .setting': {
            margin: '0 4px 0 4px'
        },
        '& .files, .file, .stage': {
            minWidth: 20,
            minHeight: 20,
            width: 20,
            height: 20
        },
        '& .checking, .setting, .plugin, .templates, .template': {
            minWidth: 17,
            minHeight: 17,
            width: 17,
            height: 17
        },
        '& .client': {
            minWidth: 22,
            minHeight: 22,
            width: 22,
            height: 22
        },
        '& .object': {
            fontSize: '1.5em'
        },
        '& p': { margin: 0 }
    }
}))((props) => <TreeItem {...props} />);

const data = [{
    id: '-1_Client',
    name: 'Сбербанк',
    children: [
        {
            id: '1',
            name: 'Child - 1',
        }
    ]
}]

async function populateWeatherData1() {
    const response = await fetch("/api/TreeView/AllData?id=ллл");
    const data = await response.text();
    console.log(data)
}

export function NavTreeview() {
    const cls = useStyles()

    populateWeatherData1()

    return (
        <div class={cls.NavTreeview}>
            <TreeView
                defaultExpanded={['1']}
                defaultCollapseIcon={<IndeterminateCheckBoxOutlinedIcon className="plus" />}
                defaultExpandIcon={<AddBoxOutlinedIcon className="minus" />}
            >
                <StyledTreeItem
                    nodeId="1"
                    label={
                        <div>
                            <Client_Icon />
                            <p>Сбербанк</p>
                        </div>
                    }
                >
                    <StyledTreeItem
                        nodeId="2"
                        label={
                            <div>
                                <HomeWorkOutlinedIcon className='object' />
                                <p>ЦОД1</p>
                            </div>
                        }
                    >
                        <StyledTreeItem
                            nodeId="7"
                            label={
                                <div>
                                    <Stage_Icon />
                                    <p>П</p>
                                </div>
                            }
                        >
                            <StyledTreeItem
                                nodeId="9"
                                label={
                                    <div>
                                        <Templates_Icon />
                                        <p>Шаблоны</p>
                                    </div>
                                }
                            >
                                <StyledTreeItem nodeId="10"
                                    label={
                                        <div>
                                            <Template_Icon />
                                            <p>Шаблон_1</p>
                                        </div>
                                    }
                                >
                                    <StyledTreeItem nodeId="101"
                                        label={
                                            <div>
                                                <Plugin_Icon />
                                                <p>Плагин_1</p>
                                            </div>
                                        }
                                    >
                                        <StyledTreeItem nodeId="103"
                                            label={
                                                <div>
                                                    <Checking_Icon />
                                                    <p>Проверка</p>
                                                </div>
                                            }
                                        />
                                        <StyledTreeItem nodeId="104"
                                            label={
                                                <div>
                                                    <Setting_Icon />
                                                    <p>Настройка</p>
                                                </div>
                                            }
                                        />
                                    </StyledTreeItem>
                                </StyledTreeItem>
                            </StyledTreeItem>
                            <StyledTreeItem
                                nodeId="92"
                                label={
                                    <div>
                                        <Files_Icon />
                                        <p>Файлы</p>
                                    </div>
                                }
                            >
                                <StyledTreeItem nodeId="107"
                                    label={
                                        <div>
                                            <File_Icon />
                                            <p>Файл_1.rvt</p>
                                        </div>
                                    }
                                />
                                <StyledTreeItem nodeId="108"
                                    label={
                                        <div>
                                            <File_Icon />
                                            <p>Файл_2.rvt</p>
                                        </div>
                                    }
                                />
                            </StyledTreeItem>
                        </StyledTreeItem>
                    </StyledTreeItem>
                </StyledTreeItem>
            </TreeView>
        </div >
    );
}
