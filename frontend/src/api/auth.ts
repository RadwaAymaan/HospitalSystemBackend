import { ILogin } from "interfaces/ILogin";
import fetchApi from "./baseFetch";

const BaseUrl = "http://localhost:5024/api/Auth/Login";

export async function Login(loginData: ILogin): Promise<any> {
    const data = await fetchApi<any>(
        BaseUrl,
        "POST",
        {},
        loginData
    );

    console.log(data);

    if (typeof localStorage !== 'undefined' && data.value?.token) {
        localStorage.setItem("token", JSON.stringify(data.value.token));
    }

    return data.successMessage;
}
