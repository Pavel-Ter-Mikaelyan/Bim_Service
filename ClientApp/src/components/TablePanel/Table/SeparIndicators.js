import React, { useState, useEffect } from 'react';

const SeparIndicator = ({ SeparIndicator_W, SeparIndicatorDisplay }) => {
    return (
        <div class='SeparIndicator'
            style={{
                left: SeparIndicator_W,
                display: SeparIndicatorDisplay
            }}
        />
    )
}

export const SeparIndicators = ({ TableInfo }) => {
    const array = TableInfo.newRowMode ?
        TableInfo.TableState.NewRowTableData.ColumnSizeData :
        TableInfo.TableState.MainTableData.ColumnSizeData

    return (
        array.map(SizeData =>
            <SeparIndicator
                SeparIndicator_W={SizeData.SeparIndicator_W}
                SeparIndicatorDisplay={SizeData.SeparIndicatorDisplay}
            />
        )
    )
}