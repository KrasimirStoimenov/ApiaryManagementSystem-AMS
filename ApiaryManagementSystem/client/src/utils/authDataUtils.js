export function setAuthData(data) {
    sessionStorage.setItem('authData', JSON.stringify(data));
}

export function getAuthData() {
    return JSON.parse(sessionStorage.getItem('authData'));
}

export function clearAuthData() {
    sessionStorage.removeItem('authData');
}