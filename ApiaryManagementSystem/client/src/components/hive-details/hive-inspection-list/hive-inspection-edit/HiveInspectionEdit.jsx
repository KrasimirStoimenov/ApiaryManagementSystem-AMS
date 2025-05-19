import { useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

import { useForm } from "../../../../hooks/useForm";
import { useGetInspectionById, useUpdateInspection } from "../../../../hooks/useInspections";

import { Button, Col, Form, Row } from "react-bootstrap";
import { toast } from 'react-toastify';

import Loading from "../../../loading/Loading";

import { formatIsoStringToFormDateValue } from "../../../../utils/dateUtils";

export default function HiveInspectionEdit() {
    const navigate = useNavigate();
    const { inspectionId } = useParams();
    const { inspection, isFetching } = useGetInspectionById(inspectionId);
    const [isUpdating, setIsUpdating] = useState(false);
    const updateInspectionHandler = useUpdateInspection();

    const submitUpdateFormHandler = async (values) => {
        try {
            setIsUpdating(true);
            await updateInspectionHandler(inspectionId, values);
            navigate(`/hives/${inspection.hiveId}/inspections`);
        } catch (error) {
            toast.error(error.message);
        } finally {
            setIsUpdating(false);
        };
    };

    const { values, changeHandler, submitHandler } = useForm(inspection, submitUpdateFormHandler, true);

    return (
        <Form onSubmit={submitHandler}>
            <fieldset>
                <legend className="text-primary">Edit Inspection</legend>
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
                <Form.Group className="field" controlId="weatherConditions">
                    {isFetching
                        ? <Loading />
                        : <Form.Control
                            type="text"
                            name="weatherConditions"
                            value={values.weatherConditions}
                            onChange={changeHandler}
                            disabled={isUpdating}
                        />
                    }
                    <Form.Label>Weather Conditions</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="observations">
                    {isFetching
                        ? <Loading />
                        : <Form.Control as="textarea" rows={3}
                            type="text"
                            name="observations"
                            value={values.observations}
                            onChange={changeHandler}
                            required
                            disabled={isUpdating}
                        />
                    }
                    <Form.Label>Observations</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="actionsTaken">
                    {isFetching
                        ? <Loading />
                        : <Form.Control as="textarea" rows={3}
                            type="text"
                            name="actionsTaken"
                            value={values.actionsTaken}
                            onChange={changeHandler}
                            disabled={isUpdating}
                        />
                    }
                    <Form.Label>Actions Taken</Form.Label>
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