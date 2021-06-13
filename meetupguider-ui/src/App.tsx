import React from 'react';
import RootRoute from './routes';
import { NavBar, Footer } from './components';

import './App.css';

const App = (): JSX.Element => (
  <div className="App">
    <NavBar />
    <RootRoute />
    <Footer />
  </div>
);

export default App;
