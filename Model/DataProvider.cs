using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    //абстрактный класс для возможности передачи данных из объектов БД
    //(например, DB_Client) в узлы дерева (TreeViewNode) и связанные
    //с ними таблицы данных (TableData)
    public abstract class DataProvider
    {
        public virtual int Id { get; set; }
        public abstract string Name { get; set; }

        [NotMapped]
        public abstract TreeViewNodeType NodeType { get; set; }
        [NotMapped]
        public virtual object Childs { get; set; }

        //получить объект дерева текущего узла(nodeId-идентификатор в дереве)
        //переопределенные методы тоже должны возвращать 
        //результат выполнения метода NodeConstructor
        public virtual TreeViewNode GetNode(int nodeId)
        {
            return NodeConstructor(nodeId);
        }
        //конструктор объекта дерева, nodeId-идентификатор в дереве
        public TreeViewNode NodeConstructor(int nodeId, string newName = null)
        {
            if (newName != null) Name = newName;
            return new TreeViewNode(Name, nodeId, Id, this);
        }

        public virtual void SetNodes() { }
        //получить подузлы
        public virtual IEnumerator GetNodes()
        {
            SetNodes();
            if (Childs == null) return null;
            MethodInfo MI = Childs.GetType().GetMethod("GetEnumerator");
            if (MI == null) return null;
            IEnumerator returnVal = (IEnumerator)MI.Invoke(Childs, null);
            return returnVal;
        }
        //установить данные для строки таблицы
        public void SetRowData(ApplicationContext db, RowContainer RC)
        {
            RC.ValueCellContainer.ForEach(Cell =>
            {
                foreach (PropertyInfo PI in GetType().GetProperties())
                {
                    //перебор атрибутов (false - без родителей)
                    foreach (ColumnAttribute Column in
                                PI.GetCustomAttributes<ColumnAttribute>(false))
                    {
                        //поиск по имени атрибута
                        if (Column.headerPropName == Cell.CI.headerPropName)
                        {
                            //установить значение свойства
                            PI.SetValue(this, Cell.value);
                        }
                    }
                }
            });
        }
        //модификация
        public abstract bool Modify(ApplicationContext db,
                                    TableData_Server newTD);


        //получить таблицу для текущего выбранного узла
        public virtual TableData_Server GetTableData(ApplicationContext db,
                                                     int nodeId)
        {

            return null;
        }



    }
}
