import { useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

import { useForm } from "../../../../hooks/useForm";
import { useGetHarvestById, useUpdateHarvest } from "../../../../hooks/useHarvests";

import { Button, Col, Form, Row } from "react-bootstrap";
import { toast } from 'react-toastify';

import Loading from "../../../loading/Loading";

import { formatIsoStringToFormDateValue } from "../../../../utils/dateUtils";

export default function HiveHarvestEdit() {
    const navigate = useNavigate();
    const { harvestId } = useParams();
    const { harvest, isFetching } = useGetHarvestById(harvestId);
    const [isUpdating, setIsUpdating] = useState(false);
    const updateHarvestHandler = useUpdateHarvest();

    const submitUpdateFormHandler = async (values) => {
        try {
            setIsUpdating(true);
            await updateHarvestHandler(harvestId, values);
            navigate(`/hives/${harvest.hiveId}/harvests`);
        } catch (error) {
            toast.error(error.message);
        } finally {
            setIsUpdating(false);
        };
    };

    const { values, changeHandler, submitHandler } = useForm(harvest, submitUpdateFormHandler, true);

    return (
        <Form onSubmit={submitHandler}>
            <fieldset>
                <legend className="text-primary">Edit Harvest</legend>
                <Form.Group className="field" controlId="date">
                    {isFetching
                        ? <Loading />
                        : <Form.Control
                            type="date"
                            name="date"
                            value={formatIsoStringToFormDateValue(values.date)}
                            onChange={changeHandler}
                            required
                            disabled={isUpdating}
                        />
                    }
                    <Form.Label>Date</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="amount">
                    {isFetching
                        ? <Loading />
                        : <Form.Control
                            type="number"
                            name="amount"
                            value={values.amount}
                            onChange={changeHandler}
                            required
                            disabled={isUpdating}
                        />
                    }
                    <Form.Label>Amount</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="product">
                    {isFetching
                        ? <Loading />
                        : <Form.Control
                            type="text"
                            name="product"
                            value={values.product}
                            onChange={changeHandler}
                            required
                            disabled={isUpdating}
                        />
                    }
                    <Form.Label>Product</Form.Label>
                </Form.Group>
                <Row>
                    <Col xs={6} md={6} lg={6}>
                        <Button className='form-control' onClick={() => navigate(-1)} disabled={isUpdating}>Back</Button>
                    </Col>
                    <Col xs={6} md={6} lg={6}>
                        <Button className='form-control' type="submit" variant='success' disabled={isUpdating}>
                            {isUpdating ? 'Updating...' : 'Update'}
                        </Button>
                    </Col>
                </Row>
            </fieldset>
        </Form>
    );
}