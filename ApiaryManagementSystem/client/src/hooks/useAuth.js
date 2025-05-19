import { useAuthContext } from "../contexts/AuthContext";

import authAPI from "../api/auth-api";
import { useEffect } from "react";

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

        await authAPI.register({ email, password });
        const loginResult = await authAPI.login({email,password});

        const authData = {
            email: email,
            accessToken: loginResult.accessToken
        };

        changeAuthState(authData);
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