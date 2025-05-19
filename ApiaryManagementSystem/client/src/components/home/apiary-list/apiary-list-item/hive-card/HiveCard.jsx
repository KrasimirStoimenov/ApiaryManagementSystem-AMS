import { Link } from 'react-router-dom';

import { Card, Col } from 'react-bootstrap';

export default function HiveCard({
    hive
}) {
    return (
        <Col>
            <Link to={`/hives/${hive._id}/details`}>
                <Card>
                    <Card.Img height='250' variant="top" src="https://thewildlifecommunity.co.uk/cdn/shop/products/SBH1_Solitary_Bee_Hive_5_Web.jpg?v=1622645194" />
                    <Card.Body>
                        <Card.Title>№{hive.number}</Card.Title>
                    </Card.Body>
                    <Card.Footer className='text-end'>Click for details</Card.Footer>
                </Card>
            </Link>
        </Col>
    );
}