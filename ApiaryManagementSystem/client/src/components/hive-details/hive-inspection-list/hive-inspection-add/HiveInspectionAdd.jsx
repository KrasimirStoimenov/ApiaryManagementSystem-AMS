import { useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

import { useForm } from "../../../../hooks/useForm";
import { useAddInspection } from "../../../../hooks/useInspections";
import { useHiveContext } from "../../../../contexts/HiveContext";

import { Button, Col, Form, Row } from "react-bootstrap";
import { toast } from 'react-toastify';

import { dateTodayInitialFormValue } from "../../../../utils/dateUtils";

export default function HiveInspectionAdd() {
    const navigate = useNavigate();
    const { hiveId } = useParams();
    const { hiveNumber, hiveColor } = useHiveContext();
    const [isAdding, setisAdding] = useState(false);
    const addInspectionHandler = useAddInspection();

    const initialValues = {
        date: dateTodayInitialFormValue(),
        weatherConditions: '',
        observations: '',
        actionsTaken: '',
        hiveDisplayName: hiveNumber ? `${hiveNumber} - ${hiveColor}` : hiveId,
        hiveId: hiveId,
    }

    const submitFormHandler = async (values) => {
        try {
            setisAdding(true);
            await addInspectionHandler(values);
            navigate(`/hives/${hiveId}/inspections`);
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
                <legend className="text-primary">Add Inspection</legend>
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
                <Form.Group className="field" controlId="weatherConditions">
                    <Form.Control
                        type="text"
                        name="weatherConditions"
                        value={values.weatherConditions}
                        onChange={changeHandler}
                        disabled={isAdding}
                    />
                    <Form.Label>Weather Conditions</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="observations">
                    <Form.Control as="textarea" rows={3}
                        type="text"
                        name="observations"
                        value={values.observations}
                        onChange={changeHandler}
                        required
                        disabled={isAdding}
                    />
                    <Form.Label>Observations</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="actionsTaken">
                    <Form.Control as="textarea" rows={3}
                        type="text"
                        name="actionsTaken"
                        value={values.actionsTaken}
                        onChange={changeHandler}
                        disabled={isAdding}
                    />
                    <Form.Label>Actions Taken</Form.Label>
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