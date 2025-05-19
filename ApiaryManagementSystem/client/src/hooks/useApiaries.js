import { useEffect, useState } from "react"

import apiariesAPI from "../api/apiaries-api";

export const useGetAllApiaries = () => {
    const [apiaries, setApiaries] = useState([]);
    const [isFetching, setIsFetching] = useState(true);

    useEffect(() => {
        (async () => {
            const result = await apiariesAPI.getAll();

            setApiaries(Object.values(result.items));
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