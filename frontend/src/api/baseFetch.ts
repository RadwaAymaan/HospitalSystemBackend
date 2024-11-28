import { header } from "./utils";
/**
 * Makes an HTTP request using the fetch API.
 * @param url - The URL to make the request to.
 * @param method - The HTTP method (e.g., GET, POST, PUT, DELETE).
 * @param body - The request body (optional).
 * @returns A promise resolving to the response data of type T.
 * @template T - The type of the response data.
 */
async function fetchApi<T>(url: string, method: string, body?: any): Promise<T> {
    const response = await fetch(url, {
        method,
        headers: header,
        body,
    });

    if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
    }

    return await response.json();
}

/**
 * Exports the fetchApi function as default.
 */
export default fetchApi;
