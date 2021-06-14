using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    //конструктор данных для таблиц
    public class TableDataConstructor
    {
        TreeViewNode currNode = null;
        ApplicationContext db = null;

        //если в дереве был выбран стандартный узел
        public TableDataConstructor(ApplicationContext db,
                                    int selectedId)
        {
            this.db = db;
            TreeNodeConstructor TNC = new TreeNodeConstructor(db);
            TreeViewNode TVN = TNC.GetTreeViewNode();
            currNode = TreeViewNode.GetNode(selectedId, TVN);
        }

        //получить данные для таблицы выбранного узла
        public TableData GetAllTableData()
        {
            if (currNode == null) return null;

            TreeViewNodeInfo CurrNodeInfo = currNode.NodeInfo;
            if (CurrNodeInfo.hasTableData == false) return null;
                              
            return currNode.NodeProvider.GetTableData();
        }
        ////добавить данные для таблицы выбранного узла
        //bool AddAllTableData(TableData TD,
        //                     TreeViewNodeType CurrNodeType)
        //{
        //    //если выбран узел 'Стадия'
        //    if (CurrNodeType == TreeViewNodeType.Stage)
        //    {
        //        DB_Stage Stage =
        //            db.DB_Stages.FirstOrDefault(q => q.Id == currNode.id);
        //        if (Stage == null) return false;
        //        //добавить информацию по таблице
        //        AddStageTableData(Stage, TD);
        //    }
        //    //если выбран узел 'Шаблон'
        //    else if (CurrNodeType == TreeViewNodeType.Template)
        //    {
        //        DB_Template Template =
        //           db.DB_Templates.FirstOrDefault(q => q.Id == currNode.id);
        //        if (Template == null) return false;
        //        //если в базе нет ни одного плагина
        //        if (db.DB_Plugin_consts.Count() == 0) return false;
        //        //добавить информацию по таблице
        //        AddTemplateTableData(Template, TD);
        //    }
        //    //если выбран узел 'Объект'
        //    else if (CurrNodeType == TreeViewNodeType.Object)
        //    {
        //        //получить информацию по столбцу 
        //        ColumnData CD = GetObjectColumnData();
        //        //добавить информацию по умолчанию для таблицы
        //        AddStandartInfo(TD, CD);
        //    }
        //    else//если выбран узел по умолчанию 
        //        //(дочерние элементы которого соответствуют строкам БД)
        //    {
        //        //получить информацию по столбцу 
        //        ColumnData CD = ColumnData.GetDefault();
        //        //добавить информацию по умолчанию для таблицы
        //        AddStandartInfo(TD, CD);
        //    }
        //    return true;
        //}
        ////добавить информацию по таблице при выбранном узле 'Шаблон'
        //void AddTemplateTableData(DB_Template Template, TableData TD)
        //{
        //    ColumnData PluginCD = new ColumnData();
        //    PluginCD.type = 1;
        //    PluginCD.headerName =
        //        TreeViewNodeInfos[TreeViewNodeType.Plugin].nodeName;
        //    PluginCD.headerPropName =
        //       TreeViewNodeInfos[TreeViewNodeType.Plugin].systemNodeName;
        //    PluginCD.comboboxData =
        //        db.DB_Plugin_consts.Select(q => q.Name).ToList();
        //    PluginCD.defVal = PluginCD.comboboxData[0];
        //    foreach (DB_Plugin Plugin in Template.DB_Plugins)
        //    {
        //        PluginCD.rowVals.Add(
        //            new rowVal { value = Plugin.DB_Plugin_const.Name });
        //        TD.rowIds.Add(Plugin.Id);
        //    }
        //    TD.columnData.Add(PluginCD);
        //}
        ////добавить информацию по таблице при выбранном узле 'Стадия'
        //void AddStageTableData(DB_Stage Stage, TableData TD)
        //{
        //    ColumnData TemplateCD = new ColumnData();
        //    ColumnData FileNameCD = new ColumnData();
        //    ColumnData FilePathCD = new ColumnData();

        //    TemplateCD.headerName =
        //        TreeViewNodeInfos[TreeViewNodeType.Template].nodeName;
        //    TemplateCD.headerPropName =
        //        TreeViewNodeInfos[TreeViewNodeType.Template].systemNodeName;
        //    TemplateCD.type = 1;
        //    TemplateCD.comboboxData =
        //        Stage.DB_Templates.Select(q => q.Name).ToList();
        //    TemplateCD.defVal = TemplateCD.comboboxData[0];

        //    FileNameCD.headerName = "Имя файла";
        //    FileNameCD.headerPropName = "FileName";
        //    FileNameCD.type = 0;

        //    FilePathCD.headerName = "Путь к файлу";
        //    FilePathCD.headerPropName = "FilePath";
        //    FilePathCD.type = 0;

        //    foreach (DB_File file in Stage.DB_Files)
        //    {
        //        TemplateCD.rowVals.Add(new rowVal { value = file.DB_Template.Name });
        //        FileNameCD.rowVals.Add(new rowVal { value = file.FileName });
        //        FilePathCD.rowVals.Add(new rowVal { value = file.FilePath });
        //        TD.rowIds.Add(file.Id);
        //    }
        //    TD.columnData.Add(TemplateCD);
        //    TD.columnData.Add(FileNameCD);
        //    TD.columnData.Add(FilePathCD);
        //}
        ////добавить стандартную информацию для таблицы
        ////(если дочерние узлы сооветствуют строкам БД)
        //void AddStandartInfo(TableData TD, ColumnData CD)
        //{
        //    currNode.children.ForEach(child =>
        //    {
        //        try
        //        {
        //            rowVal rv = new rowVal { value = child.name };
        //            CD.rowVals.Add(rv);
        //            TD.rowIds.Add(child.id);
        //        }
        //        catch { }
        //    });
        //    //добавить столбец в таблицу
        //    TD.columnData.Add(CD);
        //}
        ////получить информацию по столбцу таблицы для узла Object
        //ColumnData GetObjectColumnData()
        //{
        //    ColumnData CD = ColumnData.GetDefault();
        //    //тип ячеек таблицы - комбобокс
        //    CD.type = 1;
        //    //заполнение списка стадий
        //    CD.comboboxData =
        //        db.DB_Stage_consts.Select(q => q.Name).ToList();
        //    //значение по умолчанию
        //    CD.defVal = CD.comboboxData.Count > 0 ?
        //                            CD.comboboxData[0] : "";
        //    return CD;
        //}
    }
}
