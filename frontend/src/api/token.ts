/**
 * Retrieves the token from the localStorage and formats it as a Bearer token.
 */
export var token = `Bearer ${JSON.parse(localStorage.getItem("token"))}`;