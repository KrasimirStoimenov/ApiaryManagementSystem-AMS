import { Link } from 'react-router-dom';

import { useGetAllApiaries } from '../../../hooks/useApiaries';
import styles from './ApiaryList.module.css';

import { Accordion, Button } from 'react-bootstrap';
import ApiaryListItem from './apiary-list-item/ApiaryListItem';
import Loading from '../../loading/Loading';

export default function ApiaryList() {
    const { apiaries, isFetching } = useGetAllApiaries();

    return (
        <>
            <h1 className={`${styles['main-header']}`}>AMS-HiveManager</h1>
            <div className={`${styles.subheader}`}>
                <h4 className='text-primary'>Apiaries with hives:</h4>
                <Button as={Link} to='/apiaries/add' variant="outline-primary"><i className="bi bi-plus-lg"></i> Add Apiary</Button>
            </div>
            {isFetching
                ? <Loading />
                : <>
                    {apiaries.length > 0
                        ? <Accordion defaultActiveKey="0">
                            {apiaries.map((apiary, index) =>
                                <ApiaryListItem
                                    key={apiary._id}
                                    apiaryId={apiary._id}
                                    apiaryName={apiary.name}
                                    apiaryLocation={apiary.location}
                                    eventKey={index.toString()}
                                />
                            )}
                        </Accordion>
                        : <Accordion >
                            <Accordion.Header>It looks like you haven't added any apiaries yet. Start managing your application by adding your first apiary.</Accordion.Header>
                        </Accordion>
                    }
                </>
            }
        </>
    );
}