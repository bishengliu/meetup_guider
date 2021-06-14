/* eslint-disable @typescript-eslint/no-empty-function */
import React from 'react';
import { render } from '@testing-library/react';
import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux';
import store from '../../redux/store';
import HeatmapOverlay from './heatmap-overlay';

test('trending topics text exists', () => {
  const { queryByText } = render(
    <Provider store={store}>
      <BrowserRouter>
        <HeatmapOverlay />
      </BrowserRouter>
    </Provider>,
  );

  expect(queryByText(/trending topics/i)).toBeInTheDocument();
});

test('geo heatmap exists', () => {
  const { queryByTestId } = render(
    <Provider store={store}>
      <BrowserRouter>
        <HeatmapOverlay />
      </BrowserRouter>
    </Provider>,
  );

  expect(queryByTestId(/meetup-guider-heatmap/i)).toBeTruthy();
});
