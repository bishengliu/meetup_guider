import React from 'react';
import { Route, Switch } from 'react-router-dom';
import HeatmapOverlay from '../features/heatmap-overlay';

const RootRoute = () : JSX.Element => (
  <div className="app-content">
    <Switch>
      <Route path="/" exact><HeatmapOverlay /></Route>
      <Route><HeatmapOverlay /></Route>
    </Switch>
  </div>
);

export default RootRoute;
