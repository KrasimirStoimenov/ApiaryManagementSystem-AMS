import { useState } from "react";
import { Link, useParams } from "react-router-dom";

import { useDeleteHarvest, useGetHarvestsByHiveId } from "../../../hooks/useHarvests";
import { useHiveContext } from "../../../contexts/HiveContext";

import { Button, Col, Container, Row, Table } from "react-bootstrap";
import { toast } from 'react-toastify';

import HiveHarvestListItem from "./hive-harvest-list-item/HiveHarvestListItem";
import Loading from "../../loading/Loading";
import Delete from "../../delete/Delete";

export default function HiveHarvestList() {
    const { hiveId } = useParams();
    const { hiveNumber } = useHiveContext();
    const { hiveHarvests, isFetching, changeHarvests } = useGetHarvestsByHiveId(hiveId);

    const [showDeleteById, setShowDeleteById] = useState(null);
    const [isDeleting, setIsDeleting] = useState(false);
    const deleteHarvestHandler = useDeleteHarvest();

    const deleteClickHandler = (harvestId) => { setShowDeleteById(harvestId); };
    const closeHandler = () => { setShowDeleteById(null); };

    const deleteHandler = async (harvestId) => {
        try {
            setIsDeleting(true);
            await deleteHarvestHandler(harvestId);
            changeHarvests(oldState => oldState.filter(harvest => harvest._id !== harvestId));
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
                        <h2>Harvests for hive: <Link to={`/hives/${hiveId}/details`} >{hiveNumber ? `№${hiveNumber}` : hiveId}</Link></h2>
                    </Col>
                    <Col className='text-end pt-1'>
                        <Button as={Link} to={`/hives/${hiveId}/harvests/add`} variant='outline-primary'><i className="bi bi-plus-lg"></i> Add Harvest</Button>
                    </Col>
                </Row>
                {isFetching
                    ? <Loading />
                    : <Table border={1}>
                        <thead>
                            <tr>
                                <th>Harvest Date</th>
                                <th>Amount</th>
                                <th>Product</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {hiveHarvests.map(hiveHarvest =>
                                <HiveHarvestListItem
                                    key={hiveHarvest._id}
                                    hiveHarvest={hiveHarvest}
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