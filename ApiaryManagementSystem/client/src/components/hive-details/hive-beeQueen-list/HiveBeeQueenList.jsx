import { useState } from 'react';
import { Link, useParams } from 'react-router-dom';

import { useDeleteBeeQueen, useGetBeeQueensByHiveId } from '../../../hooks/useBeeQueens';
import { useHiveContext } from '../../../contexts/HiveContext';

import { Col, Row, Table, Container, Button } from 'react-bootstrap';
import { toast } from 'react-toastify';

import Delete from '../../delete/Delete';
import Loading from '../../loading/Loading';
import HiveBeeQueenListItem from './hive-beeQueen-list-item/HiveBeeQueenListItem';

export default function HiveBeeQueenList() {
    const { hiveId } = useParams();
    const { hiveNumber } = useHiveContext();
    const { hiveBeeQueens, isFetching, changeBeeQueens } = useGetBeeQueensByHiveId(hiveId);
    const deleteBeeQueenHandler = useDeleteBeeQueen();
    const [showDeleteById, setShowDeleteById] = useState(null);
    const [isDeleting, setIsDeleting] = useState(false);

    const deleteClickHandler = (beeQueenId) => { setShowDeleteById(beeQueenId); };
    const closeHandler = () => { setShowDeleteById(null); };

    const deleteHandler = async (beeQueenId) => {
        try {
            setIsDeleting(true);
            await deleteBeeQueenHandler(beeQueenId);
            changeBeeQueens(oldState => oldState.filter(beeQueen => beeQueen._id !== beeQueenId));
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
                        <h2>Bee Queens for hive: <Link to={`/hives/${hiveId}/details`} >{hiveNumber ? `№${hiveNumber}` : hiveId}</Link></h2>
                    </Col>
                    <Col className='text-end pt-1'>
                        {hiveBeeQueens.filter(x => x.isAlive).length > 0
                            ? <Button variant='outline-secondary' disabled><i className="bi bi-plus-lg"></i> Add Bee Queen</Button>
                            : <Button as={Link} to={`/hives/${hiveId}/beeQueens/add`} variant='outline-primary'><i className="bi bi-plus-lg"></i> Add Bee Queen</Button>
                        }
                    </Col>
                </Row>
                {isFetching
                    ? <Loading />
                    : <Table border={1}>
                        <thead>
                            <tr>
                                <th>Year</th>
                                <th>Color Mark</th>
                                <th>IsAlive</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {hiveBeeQueens.map(beeQueen =>
                                <HiveBeeQueenListItem
                                    key={beeQueen._id}
                                    beeQueen={beeQueen}
                                    deleteClickHandler={deleteClickHandler}
                                />
                            )}
                        </tbody>
                    </Table>
                }
            </Container>
        </>
    );
};