import React, { useState, useEffect } from 'react';
import { createUseStyles } from 'react-jss';

import { Table } from './Table'

export const TableContainer = () => {

    return (
        <div class='TableContainer'>
            <p>Таблица1</p>
            <Table/>
        </div>
    )
}