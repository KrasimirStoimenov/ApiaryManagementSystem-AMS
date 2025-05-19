import { useState } from 'react';
import { Link, useNavigate, useParams } from 'react-router-dom';

import { useDeleteHive, useGetHiveWithApiaryById } from '../../hooks/useHives';
import { useGetBeeQueensByHiveId } from '../../hooks/useBeeQueens';

import { Container, Row, Col, Card, Button, Image } from 'react-bootstrap';
import { toast } from 'react-toastify';

import HiveDetailsLinks from './hive-details-links/HiveDetailsLinks';
import Loading from '../loading/Loading';
import Delete from '../delete/Delete';

import { formatIsoStringToDisplayDate } from '../../utils/dateUtils';

export default function HiveDetails() {
    const { hiveId } = useParams();
    const navigate = useNavigate();
    const { hiveWithApiary, isFetching } = useGetHiveWithApiaryById(hiveId);
    const { hiveBeeQueens } = useGetBeeQueensByHiveId(hiveId);
    const hiveAliveBeeQueen = hiveBeeQueens.filter(x => x.isAlive);

    const deleteHiveHandler = useDeleteHive();
    const [showDeleteById, setShowDeleteById] = useState(null);
    const [isDeleting, setIsDeleting] = useState(false);

    const deleteClickHandler = (hiveId) => { setShowDeleteById(hiveId); };
    const closeHandler = () => { setShowDeleteById(null); };

    const deleteHandler = async (hiveId) => {
        try {
            setIsDeleting(true);
            await deleteHiveHandler(hiveId);
            navigate('/');
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

            < Container className="my-5" >
                <Card>
                    <Card.Header as="h5" className='fw-bold'>Hive Details</Card.Header>
                    {isFetching
                        ? <Loading />
                        : <Row className="justify-content-center">
                            <Col md={5} lg={5}>
                                <Image src="https://thewildlifecommunity.co.uk/cdn/shop/products/SBH1_Solitary_Bee_Hive_5_Web.jpg?v=1622645194" thumbnail />
                            </Col>
                            <Col md={7} lg={7}>
                                <Card.Body >
                                    <Card.Title>Hive №{hiveWithApiary.number}</Card.Title>
                                    <Card.Text>
                                        <strong>Location:</strong> {hiveWithApiary.apiary.name} - {hiveWithApiary.apiary.location}
                                    </Card.Text>
                                    <Card.Text>
                                        <strong>Type:</strong> {hiveWithApiary.type}
                                    </Card.Text>
                                    <Card.Text>
                                        <strong>Status:</strong> {hiveWithApiary.status}
                                    </Card.Text>
                                    <Card.Text>
                                        <strong>Color:</strong> {hiveWithApiary.color}
                                    </Card.Text>
                                    <Card.Text>
                                        <strong>Date bought:</strong> {formatIsoStringToDisplayDate(hiveWithApiary.dateBought)}
                                    </Card.Text>
                                    <Card.Text>
                                        <strong>Queen Status: </strong>
                                        {(hiveAliveBeeQueen.length > 0)
                                            ? <strong className="text-success">{`Has alive bee queen from ${hiveAliveBeeQueen[0].year} year with mark: ${hiveAliveBeeQueen[0].colorMark}`}</strong>
                                            : <strong className="text-danger">Hive is queenless. There is no live bee queen for the hive.</strong>
                                        }
                                    </Card.Text>
                                    <HiveDetailsLinks
                                        hiveId={hiveId}
                                        hiveBeeQueensCount={hiveBeeQueens.length}
                                    />
                                    <Button as={Link} to={`/hives/${hiveId}/edit`} variant="warning" className="me-2"><i className="bi bi-pencil-square"></i> Edit</Button>
                                    <Button variant="danger" onClick={() => deleteClickHandler(hiveWithApiary._id)}><i className="bi bi-trash-fill"></i> Delete</Button>
                                </Card.Body>
                            </Col>
                        </Row>
                    }
                </Card>
            </Container>
        </>
    );
};
