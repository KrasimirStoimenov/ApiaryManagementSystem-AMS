import { useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';

import { useForm } from '../../../../hooks/useForm';
import { useAddBeeQueen } from '../../../../hooks/useBeeQueens';
import { useHiveContext } from '../../../../contexts/HiveContext';

import { Button, Col, Row, Form } from 'react-bootstrap';
import { toast } from 'react-toastify';

export default function HiveBeeQueenAdd() {
    const navigate = useNavigate();
    const { hiveId } = useParams();
    const { hiveNumber, hiveColor } = useHiveContext();
    const [isAdding, setIsAdding] = useState(false);
    const addBeeQueenHandler = useAddBeeQueen();

    const initialFormValues = {
        isAlive: true,
        year: new Date().getFullYear(),
        colorMark: '',
        hiveDisplayName: hiveNumber ? `${hiveNumber} - ${hiveColor}` : hiveId,
        hiveId: hiveId,
    };

    const submitFormHandler = async (values) => {
        try {
            setIsAdding(true);
            await addBeeQueenHandler(values);
            navigate(`/hives/${hiveId}/beeQueens`);
        } catch (error) {
            toast.error(error.message);
        } finally {
            setIsAdding(false);
        };
    };

    const { values, changeHandler, submitHandler } = useForm(initialFormValues, submitFormHandler);

    return (
        <Form onSubmit={submitHandler}>
            <fieldset>
                <legend className="text-primary">Add Bee Queen</legend>
                <Form.Group className="field" controlId="year">
                    <Form.Control
                        type="number"
                        name="year"
                        value={values.year}
                        onChange={changeHandler}
                        required
                        disabled={isAdding}
                    />
                    <Form.Label>Year</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="colorMark">
                    <Form.Control
                        type="text"
                        name="colorMark"
                        value={values.colorMark}
                        onChange={changeHandler}
                        required
                        disabled={isAdding}
                    />
                    <Form.Label>Color Mark</Form.Label>
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