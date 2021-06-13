import React from 'react';
import { Link } from 'react-router-dom';
import { Navbar } from 'react-bootstrap';
import './navbar.css';

const NavBar = ():JSX.Element => (
  <Navbar bg="dark" variant="dark" expand="lg">
    <Navbar.Brand as={Link} to="/" className="brand-padding">
      <i className="fa fa-map" />
      <span> Meetup Guider</span>
    </Navbar.Brand>
  </Navbar>
);

export default NavBar;
