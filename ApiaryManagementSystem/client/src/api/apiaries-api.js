import requester from './requester'

const BASE_URL = `${import.meta.env.VITE_API_URL}/data/apiaries`;

const getAll = (userId) => {
    const params = new URLSearchParams({
        where: `_ownerId="${userId}"`
    });

    return requester.get(`${BASE_URL}?${params.toString()}`);
};
const getById = (apiaryId) => requester.get(`${BASE_URL}/${apiaryId}`);
const add = (data) => requester.post(`${BASE_URL}`, data);

const apiariesAPI = {
    getAll,
    getById,
    add,
};

export default apiariesAPI;