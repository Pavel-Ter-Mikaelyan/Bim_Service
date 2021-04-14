import React, { useState, useEffect } from 'react';
import { useStyles } from './Styles'

import { withStyles } from '@material-ui/core/styles';
import TreeView from '@material-ui/lab/TreeView';
import TreeItem from '@material-ui/lab/TreeItem';
import AddBoxOutlinedIcon from '@material-ui/icons/AddBoxOutlined';
import IndeterminateCheckBoxOutlinedIcon from '@material-ui/icons/IndeterminateCheckBoxOutlined';

import { TreeIcons } from '../Constants/Constants'

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

const data = {
    id: '1_Client',
    name: 'Сбербанк',
    children: [{
        id: '2_Object',
        name: 'ЦОД1',
        children: [{
            id: '3_Stage',
            name: 'Проектная документация',
            children: [{
                id: 'StageId=3_Templates',
                name: 'Шаблоны',
                children: [{
                    id: '4_Template',
                    name: 'Шаблон1',
                    children: [{
                        id: '5_Plugin',
                        name: 'Плагин1',
                        children: [{
                            id: 'PluginId=5_Setting',
                            name: 'Настройки'
                        },
                        {
                            id: 'PluginId=5_Checking',
                            name: 'Проверки'
                        }]
                    },
                    {
                        id: '6_Plugin',
                        name: 'Плагин2',
                        children: [{
                            id: 'PluginId=6_Setting',
                            name: 'Настройки'
                        },
                        {
                            id: 'PluginId=6_Checking',
                            name: 'Проверки'
                        }]
                    }
                    ]
                },
                {
                    id: '7_Template',
                    name: 'Шаблон2',
                    children: [{
                        id: '8_Plugin',
                        name: 'Плагин1',
                        children: [{
                            id: 'PluginId=8_Setting',
                            name: 'Настройки'
                        },
                        {
                            id: 'PluginId=8_Checking',
                            name: 'Проверки'
                        }]
                    },
                    {
                        id: '9_Plugin',
                        name: 'Плагин2',
                        children: [{
                            id: 'PluginId=9_Setting',
                            name: 'Настройки'
                        },
                        {
                            id: 'PluginId=9_Checking',
                            name: 'Проверки'
                        }]
                    }
                    ]
                }]
            },
            {
                id: 'StageId=3_Files',
                name: 'Файлы',
                children: [{
                    id: '11_File',
                    name: 'Файл1.rvt'
                },
                {
                    id: '12_File',
                    name: 'Файл2.rvt'
                }]
            }]
        },
        {
            id: '13_Stage',
            name: 'Рабочая документация',
            children: [{
                id: 'StageId=13_Templates',
                name: 'Шаблоны',
                children: [{
                    id: '14_Template',
                    name: 'Шаблон1',
                    children: [{
                        id: '15_Plugin',
                        name: 'Плагин1',
                        children: [{
                            id: 'PluginId=15_Setting',
                            name: 'Настройки'
                        },
                        {
                            id: 'PluginId=15_Checking',
                            name: 'Проверки'
                        }]
                    },
                    {
                        id: '16_Plugin',
                        name: 'Плагин2',
                        children: [{
                            id: 'PluginId=16_Setting',
                            name: 'Настройки'
                        },
                        {
                            id: 'PluginId=16_Checking',
                            name: 'Проверки'
                        }]
                    }
                    ]
                },
                {
                    id: '17_Template',
                    name: 'Шаблон2',
                    children: [{
                        id: '18_Plugin',
                        name: 'Плагин1',
                        children: [{
                            id: 'PluginId=18_Setting',
                            name: 'Настройки'
                        },
                        {
                            id: 'PluginId=18_Checking',
                            name: 'Проверки'
                        }]
                    },
                    {
                        id: '19_Plugin',
                        name: 'Плагин2',
                        children: [{
                            id: 'PluginId=19_Setting',
                            name: 'Настройки'
                        },
                        {
                            id: 'PluginId=19_Checking',
                            name: 'Проверки'
                        }]
                    }
                    ]
                }]
            },
            {
                id: 'StageId=13_Files',
                name: 'Файлы',
                children: [{
                    id: '20_File',
                    name: 'Файл1.rvt'
                },
                {
                    id: '21_File',
                    name: 'Файл2.rvt'
                }]
            }]
        }]
    }]
}

async function populateWeatherData1() {
    const response = await fetch("/api/TreeView/AllData?id=ллл");
    const data = await response.text();
    console.log(data)
}

export function NavTreeview() {
    const cls = useStyles()

    const LabelConstructor = (label) => (
        <div>
            <label.icon />
            <p>{label.name}</p>
        </div>
    )
    function DataTree(nodes) {
        const arr = nodes.id.split('_');
        const nodeType = arr[1]
        const label =
            LabelConstructor({ icon: TreeIcons.get(nodeType), name: nodes.name })
        return (
            <StyledTreeItem key={nodes.id} nodeId={nodes.id} label={label} >
                {Array.isArray(nodes.children) ?
                    nodes.children.map((node) => DataTree(node)) : null}
            </StyledTreeItem >)
    }

    return (
        <div class={cls.NavTreeview}>
            <TreeView
                defaultCollapseIcon={<IndeterminateCheckBoxOutlinedIcon className="plus" />}
                defaultExpandIcon={<AddBoxOutlinedIcon className="minus" />}
            >
                {DataTree(data)}
            </TreeView>
        </div>
    )
}
