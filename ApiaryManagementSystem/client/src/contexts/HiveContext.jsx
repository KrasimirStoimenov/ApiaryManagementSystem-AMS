import { createContext, useContext, useState } from "react";
import { Outlet } from "react-router-dom";

export const HiveContext = createContext();

export function HiveContextProvider() {
    const [hiveState, setHiveState] = useState({});

    const changeHiveState = (state) => {
        setHiveState(state);
    };

    const contextData = {
        hiveId: hiveState._id,
        hiveNumber: hiveState.number,
        hiveColor: hiveState.color,
        changeHiveState: changeHiveState
    };

    return (
        <HiveContext.Provider value={contextData}>
            <Outlet />
        </HiveContext.Provider>
    );
}

export function useHiveContext() {
    const hiveData = useContext(HiveContext);

    return hiveData;
}