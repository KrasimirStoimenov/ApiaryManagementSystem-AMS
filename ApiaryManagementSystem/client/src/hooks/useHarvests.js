import { useEffect, useState } from "react";

import { useAuthContext } from "../contexts/AuthContext";

import harvestsAPI from "../api/harvests-api";

export const useGetAllHarvests = () => {
    const [harvests, setHarvests] = useState([]);
    const [isFetching, setIsFetching] = useState(true);
    const { userId } = useAuthContext();

    useEffect(() => {
        (async () => {
            try {
                const result = await harvestsAPI.getAll(userId);
                setHarvests(Object.values(result));
            } catch (error) {
                toast.error(error.message);
            } finally {
                setIsFetching(false);
            }

        })();
    }, []);

    return {
        harvests,
        isFetching
    };
};

export const useGetHarvestById = (harvestId) => {
    const [harvest, setHarvest] = useState({
        date: '',
        amount: '',
        product: '',
        hiveId: '',
    });
    const [isFetching, setIsFetching] = useState(true);

    useEffect(() => {
        (async () => {
            const result = await harvestsAPI.getById(harvestId);

            setHarvest(result);
            setIsFetching(false);
        })();
    }, []);

    return {
        harvest,
        isFetching
    };
};

export const useGetHarvestsByHiveId = (hiveId) => {
    const [hiveHarvests, setHiveHarvests] = useState([]);
    const [isFetching, setIsFetching] = useState(true);

    useEffect(() => {
        (async () => {
            const result = await harvestsAPI.getByHiveId(hiveId);

            setHiveHarvests(Object.values(result));
            setIsFetching(false);
        })();
    }, []);

    const changeHarvests = (state) => {
        setHiveHarvests(state)
    };

    return {
        hiveHarvests,
        changeHarvests,
        isFetching
    };
};

export const useGetHarvestsCountByHiveId = (hiveId) => {
    const [hiveHarvestsCount, setHiveHarvestsCount] = useState(0);
    const [isFetching, setIsFetching] = useState(true);

    useEffect(() => {
        (async () => {
            const result = await harvestsAPI.getCountByHiveId(hiveId);

            setHiveHarvestsCount(result);
            setIsFetching(false);
        })();
    }, []);

    return {
        hiveHarvestsCount,
        isFetching
    };
};

export const useAddHarvest = () => {
    const addHarvestHandler = async (harvestData) => {
        const formattedData = {
            ...harvestData,
            date: new Date(harvestData.date).toISOString(),
        };

        delete formattedData.hiveDisplayName;
        await harvestsAPI.add(formattedData);
    };

    return addHarvestHandler;
};

export const useUpdateHarvest = () => {
    const updateHarvestHandler = async (harvestId, harvest) => { await harvestsAPI.update(harvestId, harvest); };

    return updateHarvestHandler;
};

export const useDeleteHarvest = () => {
    const deleteHarvestHandler = (harvestId) => harvestsAPI.remove(harvestId);

    return deleteHarvestHandler;
};