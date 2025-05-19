import { useGetAllHarvests } from '../../hooks/useHarvests';

import { Col, Row, Table, Container } from 'react-bootstrap';

import Loading from '../loading/Loading';
import HarvestListItem from './harvest-list-item/HarvestListItem';

export default function HarvestList() {
    const { harvests, isFetching } = useGetAllHarvests();

    return (
        <Container>
            <Row className='pb-3 pt-3'>
                <Col className='text-start text-primary'>
                    <h2>Harvests List</h2>
                </Col>
            </Row>
            {isFetching
                ? <Loading />
                : <Table border={1}>
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Amount</th>
                            <th>Product</th>
                            <th>Hive</th>
                        </tr>
                    </thead>
                    <tbody>
                        {harvests.map(harvest =>
                            <HarvestListItem
                                key={harvest._id}
                                harvest={harvest}
                            />
                        )}
                    </tbody>
                </Table>
            }
        </Container>
    );
};