import React from 'react';
import { render } from '@testing-library/react';
import Footer from './footer';

test('meetup guider text exists ', () => {
  const { queryByText } = render(
    <Footer />,
  );

  expect(queryByText(/meetup guider app/i)).toBeInTheDocument();
});
