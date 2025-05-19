import { useEffect, useState } from "react";

import { useAuthContext } from "../contexts/AuthContext";

import inspectionsAPI from "../api/inspections-api";

export const useGetAllInspections = () => {
    const [inspections, setInspections] = useState([]);
    const [isFetching, setIsFetching] = useState(true);
    const { userId } = useAuthContext();

    useEffect(() => {
        (async () => {
            try {
                const result = await inspectionsAPI.getAll(userId);
                setInspections(Object.values(result));
            } catch (error) {
                toast.error(error.message);
            } finally {
                setIsFetching(false);
            }

        })();
    }, []);

    return {
        inspections,
        isFetching
    };
};

export const useGetInspectionById = (inspectionId) => {
    const [inspection, setInspection] = useState({
        date: '',
        weatherConditions: '',
        observations: '',
        actionsTaken: '',
        hiveId: '',
    });
    const [isFetching, setIsFetching] = useState(true);

    useEffect(() => {
        (async () => {
            const result = await inspectionsAPI.getById(inspectionId);

            setInspection(result);
            setIsFetching(false);
        })();
    }, []);


    return {
        inspection,
        isFetching,
    };
}

export const useGetInspectionsByHiveId = (hiveId) => {
    const [hiveInspections, setHiveInspections] = useState([]);
    const [isFetching, setIsFetching] = useState(true);

    useEffect(() => {
        (async () => {
            const result = await inspectionsAPI.getByHiveId(hiveId);

            setHiveInspections(Object.values(result));
            setIsFetching(false);
        })();
    }, []);

    const changeInspections = (state) => {
        setHiveInspections(state)
    };

    return {
        hiveInspections,
        changeInspections,
        isFetching
    };
};

export const useGetInspectionsCountByHiveId = (hiveId) => {
    const [hiveInspectionsCount, setHiveInspectionsCount] = useState(0);
    const [isFetching, setIsFetching] = useState(true);

    useEffect(() => {
        (async () => {
            const result = await inspectionsAPI.getCountByHiveId(hiveId);

            setHiveInspectionsCount(result);
            setIsFetching(false);
        })();
    }, []);

    return {
        hiveInspectionsCount,
        isFetching
    };
};

export const useAddInspection = () => {
    const addInspectionHandler = async (inspectionData) => {
        const formattedData = {
            ...inspectionData,
            date: new Date(inspectionData.date).toISOString(),
        };

        delete formattedData.hiveDisplayName;
        await inspectionsAPI.add(formattedData);
    };

    return addInspectionHandler;
};

export const useUpdateInspection = () => {
    const updateInspectionHandler = async (inspectionId, inspection) => { await inspectionsAPI.update(inspectionId, inspection); };

    return updateInspectionHandler;
}

export const useDeleteInspection = () => {
    const deleteInspectionHandler = (inspectionId) => inspectionsAPI.remove(inspectionId);

    return deleteInspectionHandler;
};