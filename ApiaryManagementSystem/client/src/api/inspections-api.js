import requester from "./requester"

const BASE_URL = `${import.meta.env.VITE_API_URL}/data/inspections`;

const getAll = (userId) => {
    const params = new URLSearchParams({
        where: `_ownerId="${userId}"`,
        load: `hive=hiveId:hives`
    });

    return requester.get(`${BASE_URL}?${params.toString()}`);
};

const getById = (inspectionId) => requester.get(`${BASE_URL}/${inspectionId}`);
const getByHiveId = (hiveId) => {
    const params = new URLSearchParams({
        where: `hiveId="${hiveId}"`
    });

    return requester.get(`${BASE_URL}?${params.toString()}`);
};

const getCountByHiveId = (hiveId) => {
    const params = new URLSearchParams({
        where: `hiveId="${hiveId}"`
    });

    return requester.get(`${BASE_URL}?${params.toString()}&count`);
};

const add = (inspection) => requester.post(`${BASE_URL}`, inspection);
const update = (inspectionId, inspection) => requester.put(`${BASE_URL}/${inspectionId}`, inspection);
const remove = (inspectionId) => requester.del(`${BASE_URL}/${inspectionId}`);

const inspectionsAPI = {
    getAll,
    getById,
    getByHiveId,
    getCountByHiveId,
    add,
    update,
    remove
};

export default inspectionsAPI;