import React, { useState, useEffect } from 'react';

export function SourcePanel({ parent_cls }) {

    return (
        <div class={parent_cls.SourcePanel}>
            <span class="material-icons"
                style={{ fontSize: '15px' }}> table_rows</span>
            <div class="FetchData">

            </div>
        </div>
    );
}
