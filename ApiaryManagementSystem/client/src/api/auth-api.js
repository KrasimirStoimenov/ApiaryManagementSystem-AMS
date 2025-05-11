const BASE_URL = `${import.meta.env.VITE_API_URL}/api/users`;

async function login(loginData) {
    try {
        const response = await fetch(BASE_URL + '/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(loginData)
        });
        console.log(response);
        if (response.ok == false) {
            const error = await response.json();
            throw new Error(error.message);
        }

        if (response.status == 204) {
            return;
        }

        try {
            return await response.json();
        }
        catch (error) {
            throw error;
        }
    }
    catch (error) {
        throw error;
    }


};

const authAPI = {
    login,
};

export default authAPI;