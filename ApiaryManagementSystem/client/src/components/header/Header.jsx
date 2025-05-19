import { Link } from 'react-router-dom';

import { useAuthContext } from '../../contexts/AuthContext';

import { Container, Nav, Navbar } from 'react-bootstrap';

export default function Header() {
    const { email, isAuthenticated } = useAuthContext();

    return (
        <Navbar expand="lg" className="bg-body-tertiary p-2 mb-3">
            <Container>
                <Navbar.Brand as={Link} to='/'>AMS-HiveManager</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="me-auto">
                        {isAuthenticated &&
                            <>
                                <Nav.Link as={Link} to='/apiaries'>Apiaries</Nav.Link>
                                <Nav.Link as={Link} to='/hives'>Hives</Nav.Link>
                                <Nav.Link as={Link} to='/beeQueens'>BeeQueens</Nav.Link>
                                <Nav.Link as={Link} to='/inspections'>Inspections</Nav.Link>
                                <Nav.Link as={Link} to='/harvests'>Harvests</Nav.Link>
                            </>
                        }
                    </Nav>
                    {isAuthenticated
                        ? (
                            <Nav>
                                <Nav.Link>Hello {email}!</Nav.Link>
                                <Nav.Link as={Link} to='/logout'>Logout</Nav.Link>
                            </Nav>
                        )
                        : (
                            <Nav>
                                <Nav.Link as={Link} to='/login'>Login</Nav.Link>
                                <Nav.Link as={Link} to='/register'>Register</Nav.Link>
                            </Nav>
                        )
                    }
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}