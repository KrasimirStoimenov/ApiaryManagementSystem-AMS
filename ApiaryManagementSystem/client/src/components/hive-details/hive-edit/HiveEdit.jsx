import { useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';

import { useForm } from '../../../hooks/useForm';
import { useGetHiveById, useUpdateHive } from '../../../hooks/useHives';

import { Button, Col, Row, Form } from 'react-bootstrap';
import { toast } from 'react-toastify';

import Loading from '../../loading/Loading';

import { formatIsoStringToFormDateValue } from '../../../utils/dateUtils';

export default function HiveEdit() {
    const { hiveId } = useParams();
    const navigate = useNavigate();
    const { hive, isFetching } = useGetHiveById(hiveId);
    const updateHiveHandler = useUpdateHive();
    const [isUpdating, setIsUpdating] = useState(false);

    const submitUpdateFormHandler = async (values) => {
        try {
            setIsUpdating(true);
            await updateHiveHandler(hiveId, values);
            navigate(`/hives/${hiveId}/details`);
        } catch (error) {
            toast.error(error.message);
        } finally {
            setIsUpdating(false);
        };
    };

    const { values, changeHandler, submitHandler } = useForm(hive, submitUpdateFormHandler, true);

    return (
        <Form onSubmit={submitHandler}>
            <fieldset>
                <legend className="text-primary">Edit Hive</legend>
                <Form.Group className="field" controlId="number">
                    {isFetching
                        ? <Loading />
                        : <Form.Control
                            type="number"
                            name="number"
                            value={values.number}
                            onChange={changeHandler}
                            required
                            disabled={isUpdating}
                        />
                    }
                    <Form.Label>Number</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="type">
                    {isFetching
                        ? <Loading />
                        : <Form.Control
                            type="text"
                            name="type"
                            value={values.type}
                            onChange={changeHandler}
                            required
                            disabled={isUpdating}
                        />
                    }
                    <Form.Label>Type</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="status">
                    {isFetching
                        ? <Loading />
                        : <Form.Control
                            type="text"
                            name="status"
                            value={values.status}
                            onChange={changeHandler}
                            required
                            disabled={isUpdating}
                        />
                    }
                    <Form.Label>Status</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="color">
                    {isFetching
                        ? <Loading />
                        : <Form.Control
                            type="text"
                            name="color"
                            value={values.color}
                            onChange={changeHandler}
                            disabled={isUpdating}
                        />
                    }
                    <Form.Label>Color</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="dateBought">
                    {isFetching
                        ? <Loading />
                        : <Form.Control
                            type="date"
                            name="dateBought"
                            value={formatIsoStringToFormDateValue(values.dateBought)}
                            onChange={changeHandler}
                            required
                            disabled={isUpdating}
                        />
                    }
                    <Form.Label>Date Bought</Form.Label>
                </Form.Group>
                <Row>
                    <Col xs={6} md={6} lg={6}>
                        <Button className='form-control' onClick={() => navigate(-1)} disabled={isUpdating}>Back</Button>
                    </Col>
                    <Col xs={6} md={6} lg={6}>
                        <Button className='form-control' type="submit" variant='success' disabled={isUpdating}>
                            {isUpdating
                                ? 'Updating...'
                                : 'Update'}
                        </Button>
                    </Col>
                </Row>
            </fieldset>
        </Form>
    );
}