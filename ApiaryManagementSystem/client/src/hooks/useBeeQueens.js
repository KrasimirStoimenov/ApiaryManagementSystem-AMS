import { useEffect, useState } from "react";

import { useAuthContext } from "../contexts/AuthContext";

import beeQueensAPI from "../api/beeQueens-api";
import { toast } from "react-toastify";

export const useGetAllBeeQueens = () => {
    const [beeQueens, setBeeQueens] = useState([]);
    const [isFetching, setIsFetching] = useState(true);
    const { userId } = useAuthContext();

    useEffect(() => {
        (async () => {
            try {
                const result = await beeQueensAPI.getAll(userId);
                setBeeQueens(Object.values(result));
            } catch (error) {
                toast.error(error.message);
            } finally {
                setIsFetching(false);
            }

        })();
    }, []);

    return {
        beeQueens,
        isFetching
    };
};

export const useGetBeeQueenById = (beeQueenId) => {
    const [beeQueen, setBeeQueen] = useState({
        year: '',
        isAlive: '',
        colorMark: '',
        hiveId: ''
    });
    const [isFetching, setIsFetching] = useState(true);

    useEffect(() => {
        (async () => {
            const result = await beeQueensAPI.getById(beeQueenId);

            setBeeQueen(result);
            setIsFetching(false);
        })();
    }, []);

    return {
        beeQueen,
        isFetching
    };
};

export const useGetBeeQueensByHiveId = (hiveId) => {
    const [hiveBeeQueens, setHiveBeeQueens] = useState([]);
    const [isFetching, setIsFetching] = useState(true);

    useEffect(() => {
        (async () => {
            const result = await beeQueensAPI.getByHiveId(hiveId);

            setHiveBeeQueens(Object.values(result));
            setIsFetching(false);
        })();
    }, []);

    const changeBeeQueens = (state) => {
        setHiveBeeQueens(state)
    };

    return {
        hiveBeeQueens,
        changeBeeQueens,
        isFetching
    };
};

export const useAddBeeQueen = () => {
    const addBeeQueenHandler = async (data) => {

        const formattedData = {
            ...data
        };

        delete formattedData.hiveDisplayName;
        await beeQueensAPI.add(formattedData);
    };

    return addBeeQueenHandler;
};

export const useUpdateBeeQueen = () => {
    const updateBeeQueenHandler = async (beeQueenId, beeQueen) => { await beeQueensAPI.update(beeQueenId, beeQueen); };

    return updateBeeQueenHandler;
}

export const useDeleteBeeQueen = () => {
    const deleteBeeQueenHandler = (beeQueenId) => beeQueensAPI.remove(beeQueenId);

    return deleteBeeQueenHandler;
};