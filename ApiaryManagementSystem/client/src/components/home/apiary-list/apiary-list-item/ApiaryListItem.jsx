import { useState } from 'react';
import { Link } from 'react-router-dom';

import { useGetHiveByApiaryId } from '../../../../hooks/useHives';

import { Row, Accordion, Button } from 'react-bootstrap';

import HiveCard from './hive-card/HiveCard';
import Loading from '../../../loading/Loading';

export default function ApiaryListItem({
    apiaryId,
    apiaryName,
    apiaryLocation,
    eventKey
}) {
    const { apiaryHives, isFetching } = useGetHiveByApiaryId(apiaryId);
    const [showAddHiveButton, setShowAddHiveButton] = useState(true);
    const handleShow = () => setShowAddHiveButton(true);
    const handleClose = () => setShowAddHiveButton(false);

    return (
        <Accordion.Item eventKey={eventKey}>
            <Accordion.Header>{`${apiaryName} - ${apiaryLocation}`}</Accordion.Header>
            <Accordion.Body onEnter={handleShow} onExit={handleClose}>
                {((showAddHiveButton && !isFetching) &&
                    <Button as={Link} to={`/apiaries/${apiaryId}/hives/add`} variant="outline-primary" className="float-end"><i className="bi bi-plus-lg"></i> Add Hive</Button>
                )}

                {isFetching
                    ? <Loading />
                    : <>
                        {(apiaryHives.length > 0
                            ? <Row xs={1} md={3} lg={4} className="g-4">
                                {apiaryHives.map(hive =>
                                    <HiveCard
                                        key={hive._id}
                                        hive={hive}
                                    />
                                )}
                            </Row>
                            : <Row className="fst-italic p-1">It looks like you haven't added any hives yet. Start managing your apiary by adding your first hive.</Row>
                        )}

                    </>
                }
            </Accordion.Body>
        </Accordion.Item >
    );
}