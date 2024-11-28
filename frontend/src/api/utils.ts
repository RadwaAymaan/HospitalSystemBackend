import { token } from "./token";

/**
 * Defines the header object containing HTTP headers.
 */
export const header = {
    'Content-Type': 'application/json',
    'Authorization': token,
};

/**
 * Defines the base URL for API endpoints.
 */
export const baseUrl = "http://localhost:5024/api";