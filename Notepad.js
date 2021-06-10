//пример данных в таблице ДЛЯ ТЕСТА
const TableData = {
    tableName: 'Динамическая таблица',
    rowIds: [10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20],
    columnData: [
        {
            type: '0',//текст
            headerName: 'Столбец 1',
            headerPropName: 'prop2',
            defVal: 'знач. по умолч.',
            rowVals: [{ value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач1' }, { value: 'знач2' }, { value: 'знач3' }]
        },
        {
            type: 1,//список
            headerName: 'Столбец 2',
            headerPropName: 'prop1',
            defVal: 5,
            comboboxData: [1, 2, 3, 4, 5, 6, 7, 8, 9, 'текст'],
            rowVals: [{ value: 'текст' }, { value: 'текст' }, { value: 'текст' }, { value: 'текст' }, { value: 'текст' }, { value: 'текст' }, { value: 'текст' }, { value: 'текст' }, { value: 'текст' }, { value: '1' }, { value: '2' }]
        },
        {
            type: 2,//чекбокс
            headerName: 'Столбец 3',
            headerPropName: 'prop3',
            defVal: false,
            rowVals: [{ value: true }, { value: true }, { value: true }, { value: true }, { value: true }, { value: true }, { value: true }, { value: true }, { value: true }, { value: false }, { value: true }]
        }
    ]
}