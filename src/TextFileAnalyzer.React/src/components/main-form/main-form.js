import React from 'react';
import { Form, Col, Row, Button, InputGroup, FormControl } from 'react-bootstrap';

function MainForm() {

  return (
    <Form>

      <Form.Group as={Row} controlId="PathFile">
        <Form.Label column sm={2}>Путь к файлу</Form.Label>
        <Col sm={10}>
          <InputGroup className="mb-3">
            <FormControl placeholder="Выберите файл..." readOnly />
            <InputGroup.Append>
              <Button variant="primary">...</Button>
            </InputGroup.Append>
          </InputGroup>
        </Col>
      </Form.Group>

      <Form.Group as={Row} controlId="IsHeadersFirst">
        <Col sm={{ span: 10, offset: 2 }}>
          <Form.Check label="Первая строка содержит заголовки" />
        </Col>
      </Form.Group>

      <fieldset>
        <Form.Group as={Row}>
          <Form.Label as="legend" column sm={2}>Разделитель ячеек</Form.Label>
          <Col sm={10}>
            <Form.Check
              type="radio"
              label="Табуляция"
              name="Separator.SeparatorEnum"
              id="Separator.SeparatorEnum.Tab"
              value="0"
            />
            <Form.Check
              type="radio"
              label="Пробел"
              name="Separator.SeparatorEnum"
              id="Separator.SeparatorEnum.Space"
              value="1"
            />
            <Form.Check
              type="radio"
              label="Точка с запятой"
              name="Separator.SeparatorEnum"
              id="Separator.SeparatorEnum.Semicolon"
              value="2"
            />
          </Col>
        </Form.Group>
      </fieldset>

      <Form.Group as={Row}>
        <Col sm={{ span: 10, offset: 2 }}>
          <Button type="submit">Загрузить</Button>
        </Col>
      </Form.Group>
      
    </Form>
  );
}

export default MainForm;
