import React from 'react';
import MainNavbar from '../main-navbar/main-navbar';
import MainForm from '../main-form/main-form';
import { Container } from 'react-bootstrap';

function App() {

  return (
    <Container>
      <MainNavbar />
      <MainForm />
    </Container>
  );
}

export default App;
