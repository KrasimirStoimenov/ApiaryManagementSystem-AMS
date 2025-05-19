import { useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

import { useForm } from "../../../../hooks/useForm";
import { useAddHarvest } from "../../../../hooks/useHarvests";
import { useHiveContext } from "../../../../contexts/HiveContext";

import { Button, Col, Form, Row } from "react-bootstrap";
import { toast } from 'react-toastify';

import { dateTodayInitialFormValue } from "../../../../utils/dateUtils";

export default function HiveHarvestAdd() {
    const navigate = useNavigate();
    const { hiveId } = useParams();
    const { hiveNumber, hiveColor } = useHiveContext();
    const [isAdding, setisAdding] = useState(false);
    const addHarvestHandler = useAddHarvest();

    const initialValues = {
        date: dateTodayInitialFormValue(),
        amount: '',
        product: '',
        hiveDisplayName: hiveNumber ? `${hiveNumber} - ${hiveColor}` : hiveId,
        hiveId: hiveId,
    }

    const submitFormHandler = async (values) => {
        try {
            setisAdding(true);
            await addHarvestHandler(values);
            navigate(`/hives/${hiveId}/harvests`);
        } catch (error) {
            toast.error(error.message);
        } finally {
            setisAdding(false);
        };
    };

    const { values, changeHandler, submitHandler } = useForm(initialValues, submitFormHandler);

    return (
        <Form onSubmit={submitHandler}>
            <fieldset>
                <legend className="text-primary">Add Harvest</legend>
                <Form.Group className="field" controlId="date">
                    <Form.Control
                        type="date"
                        name="date"
                        value={values.date}
                        onChange={changeHandler}
                        required
                        disabled={isAdding}
                    />
                    <Form.Label>Date</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="amount">
                    <Form.Control
                        type="number"
                        name="amount"
                        value={values.amount}
                        onChange={changeHandler}
                        required
                        disabled={isAdding}
                    />
                    <Form.Label>Amount</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="product">
                    <Form.Control
                        type="text"
                        name="product"
                        value={values.product}
                        onChange={changeHandler}
                        required
                        disabled={isAdding}
                    />
                    <Form.Label>Product</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="hiveId">
                    <Form.Control
                        name="hiveId"
                        value={values.hiveDisplayName}
                        onChange={changeHandler}
                        required
                        disabled>
                    </Form.Control>
                    <Form.Label>Hive</Form.Label>
                </Form.Group>
                <Row>
                    <Col xs={6} md={6} lg={6}>
                        <Button className='form-control' onClick={() => navigate(-1)} disabled={isAdding}>Back</Button>
                    </Col>
                    <Col xs={6} md={6} lg={6}>
                        <Button className='form-control' type="submit" variant='success' disabled={isAdding}>
                            {isAdding ? 'Adding...' : 'Add'}
                        </Button>
                    </Col>
                </Row>
            </fieldset>
        </Form>
    );
}