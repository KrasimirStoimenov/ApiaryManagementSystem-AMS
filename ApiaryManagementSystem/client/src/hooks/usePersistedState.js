import { useState } from "react";

export default function usePersistedState(key, initialState) {
    const [state, setState] = useState(() => {
        const persistedState = sessionStorage.getItem(key);
        if (!persistedState) {
            return initialState;
        }

        const persistedData = JSON.parse(persistedState);

        return persistedData;
    });

    const updateState = (value) => {
        sessionStorage.setItem(key, JSON.stringify(value));

        setState(value);
    };

    return [state, updateState];
}