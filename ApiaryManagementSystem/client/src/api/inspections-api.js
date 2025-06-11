import requester from "./requester"

const BASE_URL = `${import.meta.env.VITE_API_URL}/api/inspections`;

const getAll = () => requester.get(`${BASE_URL}`);

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