
import { useAuthContext } from '../../contexts/AuthContext';

import ApiaryList from './apiary-list/ApiaryList';
import GuestHome from './guest-home/GuestHome';

export default function Home() {
    const { isAuthenticated } = useAuthContext();


    return (
        <>
            {isAuthenticated
                ? <ApiaryList />
                : <GuestHome />
            }
        </>
    );
}