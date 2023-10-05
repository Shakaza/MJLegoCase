import type { Component } from 'solid-js';

import logo from './logo.svg';
import styles from './App.module.css';
import { Route, Router, Routes } from '@solidjs/router';
import { OverviewPage } from './Pages/OverviewPage/OverviewPage';

const App: Component = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" component={OverviewPage} />
      </Routes>
    </Router>
  );
};

export default App;
