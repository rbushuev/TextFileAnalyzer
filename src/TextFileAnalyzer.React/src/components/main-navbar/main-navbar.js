import React from 'react';
import { Navbar } from 'react-bootstrap'

function MainNavbar() {

  return (
    <Navbar>
        <Navbar.Brand href="#home">Анализатор текстовых файлов</Navbar.Brand>
        <Navbar.Toggle />
        <Navbar.Collapse className="justify-content-end">
            <Navbar.Text>
                Development: <a href="https://github.com/rbushuev">Roman Bushuev</a>
            </Navbar.Text>
        </Navbar.Collapse>
    </Navbar>
  );
}

export default MainNavbar;
