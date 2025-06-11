import requester from './requester'

const BASE_URL = `${import.meta.env.VITE_API_URL}/api/beeQueens`;

const getAll = () => requester.get(`${BASE_URL}`);

const getById = (beeQueenId) => requester.get(`${BASE_URL}/${beeQueenId}`);
const getByHiveId = (hiveId) => {
    const params = new URLSearchParams({
        where: `hiveId="${hiveId}"`
    });

    return requester.get(`${BASE_URL}?${params.toString()}`);
};

const add = (beeQueen) => requester.post(`${BASE_URL}`, beeQueen);
const update = (beeQueenId, beeQueen) => requester.put(`${BASE_URL}/${beeQueenId}`, beeQueen);
const remove = (beeQueenId) => requester.del(`${BASE_URL}/${beeQueenId}`);

const beeQueensAPI = {
    getAll,
    getById,
    getByHiveId,
    add,
    update,
    remove,
};

export default beeQueensAPI;