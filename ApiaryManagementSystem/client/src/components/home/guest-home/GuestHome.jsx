import { Link } from 'react-router-dom';

import { Container, Row, Col, Button } from 'react-bootstrap';

export default function GuestHome() {
    return (
        <Container className="text-center" style={{ padding: '5em' }}>
            <h1>Welcome to Apiary Management System</h1>
            <h1 className=" mb-5">(AMS-HiveManager)</h1>
            <Row className="justify-content-center">
                <Col md={8}>
                    <p className="lead">
                        The ultimate tool for beekeepers to manage and monitor their apiaries effectively.
                    </p>
                    <p>
                        Track hive locations, log inspections, record honey production, and manage tasks all in one place.
                    </p>
                    <Button as={Link} to="/login" variant="primary" className="me-2">Login</Button>
                    <Button as={Link} to="/register" variant="secondary" >Register</Button>
                </Col>
            </Row>
        </Container>
    );
};
