import { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';

import { useLogin } from '../../hooks/useAuth';
import { useForm } from '../../hooks/useForm';

import { Container, Row, Col, Card, Form, Button, FloatingLabel } from 'react-bootstrap';
import { toast } from 'react-toastify';

const initialFormValues = {
    email: '',
    password: ''
};

export default function Login() {
    const navigate = useNavigate();
    const login = useLogin();
    const [isSigningIn, setIsSigningIn] = useState(false);

    const loginHandler = async (values) => {
        if (values.email == '' || values.password == '') {
            return toast.warning('All fields are required!');
        }

        try {
            setIsSigningIn(true);
            await login(values);
            navigate('/');
        } catch (error) {
            toast.error(error.message);
        }
        finally {
            setIsSigningIn(false);
        }
    };

    const { values, changeHandler, submitHandler } = useForm(initialFormValues, loginHandler);

    return (
        <Container>
            <Row className="justify-content-center">
                <Col md={6} lg={4}>
                    <Card className="shadow-sm">
                        <Card.Body>
                            <Card.Title as={'h2'} className="text-center mb-4 mt-2">Login</Card.Title>
                            <Form onSubmit={submitHandler}>
                                <Form.Group controlId="formBasicEmail" className="mb-4">
                                    <FloatingLabel controlId="floatingEmailAddress" label="Email address">
                                        <Form.Control
                                            type="email"
                                            name="email"
                                            placeholder="Enter email"
                                            value={values.email}
                                            onChange={changeHandler}
                                            disabled={isSigningIn}
                                        />
                                    </FloatingLabel>
                                </Form.Group>
                                <Form.Group controlId="formBasicPassword" className="mb-4">
                                    <FloatingLabel controlId="floatingPassword" label="Password">
                                        <Form.Control
                                            type="password"
                                            name="password"
                                            placeholder="Password"
                                            value={values.password}
                                            onChange={changeHandler}
                                            disabled={isSigningIn}
                                        />
                                    </FloatingLabel>
                                </Form.Group>
                                <Button variant="primary" type="submit" className="w-100 p-2" disabled={isSigningIn}>
                                    {isSigningIn
                                        ? 'Signing in...'
                                        : 'Sign In'}
                                </Button>
                            </Form>
                        </Card.Body>
                        <Card.Footer className="text-center">
                            <small>Don't have an account? <Link to='/register'>Sign Up</Link></small>
                        </Card.Footer>
                    </Card>
                </Col>
            </Row>
        </Container>
    );
};
