import { useEffect, useState } from "react"

import { useAuthContext } from "../contexts/AuthContext";

import apiariesAPI from "../api/apiaries-api";

export const useGetAllApiaries = () => {
    const [apiaries, setApiaries] = useState([]);
    const [isFetching, setIsFetching] = useState(true);
    const { userId } = useAuthContext();

    useEffect(() => {
        (async () => {
            const result = await apiariesAPI.getAll(userId);

            setApiaries(Object.values(result));
            setIsFetching(false);
        })();
    }, []);

    return {
        apiaries,
        isFetching
    };
};

export const useGetApiaryById = (apiaryId) => {
    const [apiary, setApiary] = useState([]);
    const [isFetching, setIsFetching] = useState(true);

    useEffect(() => {
        (async () => {
            const result = await apiariesAPI.getById(apiaryId);

            setApiary(result);
            setIsFetching(false);
        })();
    }, []);

    return {
        apiary,
        isFetching
    };
};

export const useAddApiary = () => {
    const addApiaryHandler = async (data) => await apiariesAPI.add(data);

    return addApiaryHandler;
};