import React, { useState, useEffect } from 'react'; 

const SeparIndicator = (SeparIndicator_W, SeparIndicatorDisplay) => {
    return (
        <div class='SeparIndicator'
            style={{
                left: SeparIndicator_W,
                display: SeparIndicatorDisplay
            }}
        />
    )
}

export const SeparIndicators = (TableInfo) => {
    return (
        TableInfo.TableState.ColumnSizeData.map(SizeData =>
            SeparIndicator(SizeData.SeparIndicator_W,
                SizeData.SeparIndicatorDisplay)
        )
    )
}