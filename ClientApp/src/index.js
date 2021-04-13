import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Switch } from 'react-router-dom';
import { Route } from 'react-router';
import registerServiceWorker from './registerServiceWorker';

import './Style.css';
import { MainPanel } from './components/MainPanel/MainPanel';
import { HeadBlock } from './components/HeadBlock/HeadBlock';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(
    <BrowserRouter basename={baseUrl}>
        <HeadBlock />
        <MainPanel/>
        {/*<Switch>
            <Route exact path='/' component={Counter} />
            <Route exact path='/counter' component={Counter} />
            <Route exact path='/fetch-data' component={FetchData} />
        </Switch>*/}
    </BrowserRouter>,
    rootElement);

registerServiceWorker();

