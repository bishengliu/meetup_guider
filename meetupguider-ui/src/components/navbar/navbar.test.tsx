import React from 'react';
import { render } from '@testing-library/react';
import { BrowserRouter } from 'react-router-dom';
import NavBar from './narbar';

test('meetup guider text exists ', () => {
  const { queryByText } = render(
    <BrowserRouter>
      <NavBar />
    </BrowserRouter>
    ,
  );

  expect(queryByText(/meetup guider/i)).toBeInTheDocument();
});
