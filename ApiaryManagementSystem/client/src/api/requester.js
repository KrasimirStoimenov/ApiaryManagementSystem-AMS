import { getAuthData } from "../utils/authDataUtils";

async function requester(method, url, data) {
    const options = createOptions(method, data);

    try {
        const response = await fetch(url, options);

        if (response.ok == false) {
            const error = await response.json();
            const errors = Object.values(error.errors).join("\r\n");

            throw new Error(errors);
        }

        if (response.status == 200 && url.includes('register')) {
            return;
        }

        try {
            return await response.json();
        }
        catch (error) {
            throw error;
        }
    } catch (error) {
        throw error;
    }
}

function createOptions(method, data) {
    const options = {
        method,
        headers: {}
    };

    if (data != undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    const authData = getAuthData();
    if (authData && authData.accessToken) {
        options.headers['Authorization'] = 'Bearer ' + authData.accessToken;
    }

    return options;
}

const get = requester.bind(null, 'GET');
const post = requester.bind(null, 'POST');
const put = requester.bind(null, 'PUT');
const del = requester.bind(null, 'DELETE');

export default requester = {
    get,
    post,
    put,
    del
};