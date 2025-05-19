import { useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';

import { useForm } from '../../hooks/useForm';
import { useAddHive } from '../../hooks/useHives';
import { useGetApiaryById } from '../../hooks/useApiaries';

import { Button, Col, Row, Form } from 'react-bootstrap';
import { toast } from 'react-toastify';

import Loading from '../loading/Loading';
import { dateTodayInitialFormValue } from '../../utils/dateUtils';

export default function HiveAdd() {
    const { apiaryId } = useParams();
    const navigate = useNavigate();
    const addHiveHandler = useAddHive();
    const [isAdding, setIsAdding] = useState(false);
    const { apiary, isFetching: isApiaryFetching } = useGetApiaryById(apiaryId);

    const initialFormValues = {
        number: '',
        type: '',
        status: '',
        color: '',
        dateBought: dateTodayInitialFormValue(),
        apiaryId: apiaryId,
    };

    const submitHiveHandler = async (values) => {
        try {
            setIsAdding(true);
            const hive = await addHiveHandler(values);
            navigate(`/hives/${hive._id}/details`);
        } catch (error) {
            toast.error(error.message);
        } finally {
            setIsAdding(false);
        };
    };

    const { values, changeHandler, submitHandler } = useForm(initialFormValues, submitHiveHandler);

    return (
        <Form onSubmit={submitHandler}>
            <fieldset>
                <legend className="text-primary">Add Hive</legend>
                <Form.Group className="field" controlId="number">
                    <Form.Control
                        type="number"
                        name="number"
                        value={values.number}
                        onChange={changeHandler}
                        required
                        disabled={isAdding}
                    />
                    <Form.Label>Number</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="type">
                    <Form.Control
                        type="text"
                        name="type"
                        value={values.type}
                        onChange={changeHandler}
                        required
                        disabled={isAdding}
                    />
                    <Form.Label>Type</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="status">
                    <Form.Control
                        type="text"
                        name="status"
                        value={values.status}
                        onChange={changeHandler}
                        required
                        disabled={isAdding}
                    />
                    <Form.Label>Status</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="color">
                    <Form.Control
                        type="text"
                        name="color"
                        value={values.color}
                        onChange={changeHandler}
                        disabled={isAdding}
                    />
                    <Form.Label>Color</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="dateBought">
                    <Form.Control
                        type="date"
                        name="dateBought"
                        value={values.dateBought}
                        onChange={changeHandler}
                        required
                        disabled={isAdding}
                    />
                    <Form.Label>Date Bought</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="apiaryId">
                    {
                        isApiaryFetching
                            ? <Loading />
                            : <Form.Control
                                type="text"
                                name="apiaryId"
                                value={`${apiary.name} - ${apiary.location}`}
                                required
                                disabled
                            />
                    }
                    <Form.Label>Apiary</Form.Label>
                </Form.Group>
                <Row>
                    <Col xs={6} md={6} lg={6}>
                        <Button className='form-control' onClick={() => navigate(-1)} disabled={isAdding}>Back</Button>
                    </Col>
                    <Col xs={6} md={6} lg={6}>
                        <Button className='form-control' type="submit" variant='success' disabled={isAdding}>
                            {isAdding
                                ? 'Adding...'
                                : 'Add'}
                        </Button>
                    </Col>
                </Row>
            </fieldset>
        </Form>
    );
}