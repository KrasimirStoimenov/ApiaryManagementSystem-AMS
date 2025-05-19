import requester from './requester'

const BASE_URL = `${import.meta.env.VITE_API_URL}/api/apiaries`;

const getAll = () => requester.get(`${BASE_URL}`);
const getById = (apiaryId) => requester.get(`${BASE_URL}/${apiaryId}`);
const add = (data) => requester.post(`${BASE_URL}`, data);

const apiariesAPI = {
    getAll,
    getById,
    add,
};

export default apiariesAPI;