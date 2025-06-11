import requester from "./requester"

const BASE_URL = `${import.meta.env.VITE_API_URL}/api/harvests`;

const getAll = () => requester.get(`${BASE_URL}`);

const getById = (harvestId) => requester.get(`${BASE_URL}/${harvestId}`);
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

const add = (harvest) => requester.post(`${BASE_URL}`, harvest);
const update = (harvestId, harvest) => requester.put(`${BASE_URL}/${harvestId}`, harvest);
const remove = (harvestId) => requester.del(`${BASE_URL}/${harvestId}`);

const harvestsAPI = {
    getAll,
    getById,
    getByHiveId,
    getCountByHiveId,
    add,
    update,
    remove
};

export default harvestsAPI;