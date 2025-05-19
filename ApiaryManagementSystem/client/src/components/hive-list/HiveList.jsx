import { useGetAllHives } from '../../hooks/useHives';

import { Col, Row, Table, Container } from 'react-bootstrap';

import Loading from '../loading/Loading';
import HiveListItem from './hive-list-item/HiveListItem';

export default function HiveList() {
    const { hives, isFetching } = useGetAllHives();

    return (
        <Container>
            <Row className='pb-3 pt-3'>
                <Col className='text-start text-primary'>
                    <h2>Hives List</h2>
                </Col>
            </Row>
            {isFetching
                ? <Loading />
                : <Table border={1}>
                    <thead>
                        <tr>
                            <th>Number</th>
                            <th>Type</th>
                            <th>Color</th>
                            <th>Date Bought</th>
                            <th>Apiary</th>
                        </tr>
                    </thead>
                    <tbody>
                        {hives.map(hive =>
                            <HiveListItem
                                key={hive._id}
                                hive={hive}
                            />
                        )}
                    </tbody>
                </Table>
            }
        </Container>
    );
};