import { createContext, useContext } from "react";

import usePersistedState from "../hooks/usePersistedState";

export const AuthContext = createContext();

export function AuthContextProvider(props) {
    const [authState, updateState] = usePersistedState('authData', {});

    const changeAuthState = (state) => {
        updateState(state);
    };

    const contextData = {
        email: authState.email,
        accessToken: authState.accessToken,
        isAuthenticated: !!authState.email,
        changeAuthState
    };

    return (
        <AuthContext.Provider value={contextData}>
            {props.children}
        </AuthContext.Provider>
    );
}

export function useAuthContext() {
    const authData = useContext(AuthContext);

    return authData;
}

// {
//     "email": "test@test.com",
//     "password": "Test123!"
//   }