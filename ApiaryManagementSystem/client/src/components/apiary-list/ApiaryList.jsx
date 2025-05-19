import { useGetAllApiaries } from '../../hooks/useApiaries';

import { Col, Row, Table, Container } from 'react-bootstrap';

import Loading from '../loading/Loading';
import ApiaryListItem from './apiary-list-item/ApiaryListItem';

export default function ApiaryList() {
    const { apiaries, isFetching } = useGetAllApiaries();

    return (
        <Container>
            <Row className='pb-3 pt-3'>
                <Col className='text-start text-primary'>
                    <h2>Apiaries List</h2>
                </Col>
            </Row>
            {isFetching
                ? <Loading />
                : <Table border={1}>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Location</th>
                        </tr>
                    </thead>
                    <tbody>
                        {apiaries.map(apiary =>
                            <ApiaryListItem
                                key={apiary._id}
                                apiary={apiary}
                            />
                        )}
                    </tbody>
                </Table>
            }
        </Container>
    );
};