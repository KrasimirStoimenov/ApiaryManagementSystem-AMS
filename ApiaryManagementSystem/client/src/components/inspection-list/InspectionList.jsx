import { useGetAllInspections } from '../../hooks/useInspections';

import { Col, Row, Table, Container } from 'react-bootstrap';

import Loading from '../loading/Loading';
import InspectionListItem from './inspection-list-item/InspectionListItem';

export default function InspectionList() {
    const { inspections, isFetching } = useGetAllInspections();

    return (
        <Container>
            <Row className='pb-3 pt-3'>
                <Col className='text-start text-primary'>
                    <h2>Inspections List</h2>
                </Col>
            </Row>
            {isFetching
                ? <Loading />
                : <Table border={1}>
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Weather Conditions</th>
                            <th>Observations</th>
                            <th>Actions Taken</th>
                            <th>Hive</th>
                        </tr>
                    </thead>
                    <tbody>
                        {inspections.map(inspection =>
                            <InspectionListItem
                                key={inspection._id}
                                inspection={inspection}
                            />
                        )}
                    </tbody>
                </Table>
            }
        </Container>
    );
};