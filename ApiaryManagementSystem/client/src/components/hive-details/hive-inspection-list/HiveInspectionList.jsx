import { useState } from 'react';
import { Link, useParams } from 'react-router-dom';

import { useDeleteInspection, useGetInspectionsByHiveId } from '../../../hooks/useInspections';
import { useHiveContext } from '../../../contexts/HiveContext';

import { Col, Row, Table, Container, Button } from 'react-bootstrap';
import { toast } from 'react-toastify';

import HiveInspectionListItem from './hive-inspection-list-item/HiveInspectionListItem';
import Loading from '../../loading/Loading';
import Delete from '../../delete/Delete';

export default function HiveInspectionList() {
    const { hiveId } = useParams();
    const { hiveNumber } = useHiveContext();
    const [showDeleteById, setShowDeleteById] = useState(null);
    const [isDeleting, setIsDeleting] = useState(false);

    const { hiveInspections, isFetching, changeInspections } = useGetInspectionsByHiveId(hiveId);
    const deleteInspectionHandler = useDeleteInspection();

    const deleteClickHandler = (inspectionId) => { setShowDeleteById(inspectionId); };
    const closeHandler = () => { setShowDeleteById(null); };

    const deleteHandler = async (inspectionId) => {
        try {
            setIsDeleting(true);
            await deleteInspectionHandler(inspectionId);
            changeInspections(oldState => oldState.filter(inspection => inspection._id !== inspectionId));
        } catch (error) {
            toast.error(error.message);
        } finally {
            setIsDeleting(false);
            setShowDeleteById(null);
        };
    };

    return (
        <>
            {showDeleteById && (
                <Delete
                    onClose={closeHandler}
                    onDelete={() => deleteHandler(showDeleteById)}
                    isDeleting={isDeleting}
                />
            )}
            <Container>
                <Row className='pb-3 pt-3'>
                    <Col className='text-start text-primary'>
                        <h2>Inspections for hive: <Link to={`/hives/${hiveId}/details`} >{hiveNumber ? `№${hiveNumber}` : hiveId}</Link></h2>
                    </Col>
                    <Col className='text-end pt-1'>
                        <Button as={Link} to={`/hives/${hiveId}/inspections/add`} variant='outline-primary'><i className="bi bi-plus-lg"></i> Add Inspection</Button>
                    </Col>
                </Row>
                {isFetching
                    ? <Loading />
                    : <Table border={1}>
                        <thead>
                            <tr>
                                <th>Inspection Date</th>
                                <th>Weather Conditions</th>
                                <th>Observations</th>
                                <th>Actions Taken</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {hiveInspections.map(hiveInspection =>
                                <HiveInspectionListItem
                                    key={hiveInspection._id}
                                    hiveInspection={hiveInspection}
                                    deleteClickHandler={deleteClickHandler}
                                />
                            )}
                        </tbody>
                    </Table>
                }
            </Container>
        </>
    );
}