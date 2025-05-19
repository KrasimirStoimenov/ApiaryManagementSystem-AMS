import requester from './requester'

const BASE_URL = `${import.meta.env.VITE_API_URL}/data/hives`;

const getAll = (userId) => {
    const params = new URLSearchParams({
        where: `_ownerId="${userId}"`,
        load: `apiary=apiaryId:apiaries`
    });

    return requester.get(`${BASE_URL}?${params.toString()}`);
};

const getById = (hiveId) => requester.get(`${BASE_URL}/${hiveId}`);

const getHiveWithApiaryById = (hiveId) => {
    const params = new URLSearchParams({
        load: `apiary=apiaryId:apiaries`
    });

    return requester.get(`${BASE_URL}/${hiveId}?${params.toString()}`);
};

const getByApiaryId = (apiaryId) => {
    const params = new URLSearchParams({
        where: `apiaryId="${apiaryId}"`
    });

    return requester.get(`${BASE_URL}?${params.toString()}`);
};

const add = (hive) => requester.post(`${BASE_URL}`, hive);
const update = (hiveId, hive) => requester.put(`${BASE_URL}/${hiveId}`, hive);
const remove = (hiveId) => requester.del(`${BASE_URL}/${hiveId}`);

const hivesAPI = {
    getAll,
    getById,
    getHiveWithApiaryById,
    getByApiaryId,
    add,
    update,
    remove
};

export default hivesAPI;