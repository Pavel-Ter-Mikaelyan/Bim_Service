return (
    <div class={cls.NavTreeview}>
        <TreeView
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