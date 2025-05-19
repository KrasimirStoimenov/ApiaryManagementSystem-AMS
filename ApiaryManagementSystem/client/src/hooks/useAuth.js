import { useAuthContext } from "../contexts/AuthContext";

import authAPI from "../api/auth-api";

export const useLogin = () => {
    const { changeAuthState } = useAuthContext();
    const loginHandler = async (loginData) => {

        const result = await authAPI.login(loginData);

        const authData = {
            email: loginData.email,
            accessToken: result.accessToken
        };

        changeAuthState(authData);
    };

    return loginHandler;
}

export const useRegister = () => {
    const { changeAuthState } = useAuthContext();
    const registerHandler = async (email, password) => {

        const result = await authAPI.register({ email, password });
        delete result.password;

        changeAuthState(result);
    };

    return registerHandler;
}

export const useLogout = () => {
    const { changeAuthState } = useAuthContext();
    const logoutHandler = () => {
        changeAuthState({});
    };

    return logoutHandler;
}