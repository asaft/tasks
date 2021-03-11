import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Tasks } from './components/Tasks';
import { Provider } from 'react-redux';

import './custom.css'
import { store } from './redux/store';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Provider store={store}>
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/tasks/:id' render={(props)=><Tasks {...props} />} />
        <Route path='/fetch-data' component={FetchData} />
      </Layout>
      </Provider>
    );
  }
}
