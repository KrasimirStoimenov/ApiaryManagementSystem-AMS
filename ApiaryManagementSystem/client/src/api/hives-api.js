import requester from './requester'

const BASE_URL = `${import.meta.env.VITE_API_URL}`;
const BASE_HIVES_URL = `${BASE_URL}/api/hives`;

const getAll = () =>  requester.get(`${BASE_HIVES_URL}`);
const getById = (hiveId) => requester.get(`${BASE_URL}/${hiveId}`);

const getHiveWithApiaryById = (hiveId) => {
    const params = new URLSearchParams({
        load: `apiary=apiaryId:apiaries`
    });

    return requester.get(`${BASE_URL}/${hiveId}?${params.toString()}`);
};

const getHivesByApiaryId = (apiaryId) => requester.get(`${BASE_URL}/api/apiaries/${apiaryId}/hives`);

const add = (hive) => requester.post(`${BASE_HIVES_URL}`, hive);
const update = (hiveId, hive) => requester.put(`${BASE_URL}/${hiveId}`, hive);
const remove = (hiveId) => requester.del(`${BASE_URL}/${hiveId}`);

const hivesAPI = {
    getAll,
    getById,
    getHiveWithApiaryById,
    getHivesByApiaryId,
    add,
    update,
    remove
};

export default hivesAPI;