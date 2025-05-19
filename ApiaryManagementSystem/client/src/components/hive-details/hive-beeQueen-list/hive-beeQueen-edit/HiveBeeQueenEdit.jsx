import { useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

import { useForm } from "../../../../hooks/useForm";
import { useGetBeeQueenById, useUpdateBeeQueen } from "../../../../hooks/useBeeQueens";

import { Button, Col, Form, Row } from "react-bootstrap";
import { toast } from 'react-toastify';

import Loading from "../../../loading/Loading";

export default function HiveBeeQueenEdit() {
    const navigate = useNavigate();
    const { beeQueenId } = useParams();
    const { beeQueen, isFetching } = useGetBeeQueenById(beeQueenId);
    const [isUpdating, setIsUpdating] = useState(false);
    const updateBeeQueenHandler = useUpdateBeeQueen();

    const submitUpdateFormHandler = async () => {
        try {
            setIsUpdating(true);
            await updateBeeQueenHandler(beeQueenId, values);
            navigate(`/hives/${beeQueen.hiveId}/beeQueens`);
        } catch (error) {
            toast.error(error.message);
        } finally {
            setIsUpdating(false);
        };
    };

    const { values, changeHandler, submitHandler } = useForm(beeQueen, submitUpdateFormHandler, true);

    return (
        <Form onSubmit={submitHandler}>
            <fieldset>
                <legend className="text-primary">Edit Bee Queen</legend>
                <Form.Group className="field" controlId="year">
                    {isFetching
                        ? <Loading />
                        : <Form.Control
                            type="number"
                            name="year"
                            value={values.year}
                            onChange={changeHandler}
                            required
                            disabled={isUpdating}
                        />
                    }
                    <Form.Label>Year</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="colorMark">
                    {isFetching
                        ? <Loading />
                        : <Form.Control
                            type="text"
                            name="colorMark"
                            value={values.colorMark}
                            onChange={changeHandler}
                            required
                            disabled={isUpdating}
                        />
                    }
                    <Form.Label>Color Mark</Form.Label>
                </Form.Group>
                <Form.Group className="field" controlId="isAlive">
                    {isFetching
                        ? <Loading />
                        : <Form.Check
                            type="checkbox"
                            name="isAlive"
                            checked={values.isAlive}
                            onChange={changeHandler}
                            disabled={isUpdating}>
                        </Form.Check>
                    }
                    <Form.Label>Is Alive</Form.Label>
                </Form.Group>
                <Row>
                    <Col xs={6} md={6} lg={6}>
                        <Button className='form-control' onClick={() => navigate(-1)} disabled={isUpdating}>Back</Button>
                    </Col>
                    <Col xs={6} md={6} lg={6}>
                        <Button className='form-control' type="submit" variant='success' disabled={isUpdating}>
                            {isUpdating ? 'Update...' : 'Update'}
                        </Button>
                    </Col>
                </Row>
            </fieldset>
        </Form>
    );
}