import { Navigate, Outlet } from "react-router-dom";
import { useAuthContext } from "../../contexts/AuthContext";

export default function PrivateRoutes() {
    const { isAuthenticated } = useAuthContext();

    return (
        isAuthenticated
            ? <Outlet />
            : <Navigate to='/login' />
    );
}