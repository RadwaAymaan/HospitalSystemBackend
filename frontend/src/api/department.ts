
import { IDepartment, IDepartmentList } from "interfaces/IDepartment";
import fetchApi from "./baseFetch";

const BaseUrl = "http://localhost:5024/api/Department";

export async function GetDepartment(): Promise<IDepartmentList[]> {
  const data = await fetchApi<any>(BaseUrl, "GET", );
  let p = data.value;
  return p;
 
}



