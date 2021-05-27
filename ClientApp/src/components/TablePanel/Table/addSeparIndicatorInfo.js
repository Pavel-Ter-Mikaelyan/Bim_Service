
export const addSeparIndicatorInfo = (ColumnSizeData, showSeparIndicator, ColumnIndex) => {

    let SeparIndicator_W = 0
    ColumnSizeData.forEach((SizeData, i) => {
        //определение смещения сепаратора
        if (SeparIndicator_W != 0) SeparIndicator_W += 3
        SeparIndicator_W += SizeData.column_w
        SizeData.SeparIndicator_W = SeparIndicator_W
        //видимость сепаратора       
        if (showSeparIndicator && ColumnIndex == i) {
            SizeData.SeparIndicatorDisplay = 'block'
        }
        else {
            SizeData.SeparIndicatorDisplay = 'none'
        }
    })
}
