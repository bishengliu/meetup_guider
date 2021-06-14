import React from 'react';
import { render } from '@testing-library/react';
import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux';
import store from './redux/store';
import App from './App';

test('meetup guider text exists ', () => {
  const { queryByText } = render(
    <Provider store={store}>
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </Provider>,
  );

  expect(queryByText(/meetup guider app/i)).toBeInTheDocument();
});

test('navbar exists ', () => {
  const { queryByTestId } = render(
    <Provider store={store}>
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </Provider>,
  );

  expect(queryByTestId(/meetup-guider-navbar/i)).toBeTruthy();
});

test('geo heatmap exists ', () => {
  const { queryByTestId } = render(
    <Provider store={store}>
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </Provider>,
  );

  expect(queryByTestId(/meetup-guider-heatmap/i)).toBeTruthy();
});

test('footer exists ', () => {
  const { queryByTestId } = render(
    <Provider store={store}>
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </Provider>,
  );

  expect(queryByTestId(/meetup-guider-footer/i)).toBeTruthy();
});
