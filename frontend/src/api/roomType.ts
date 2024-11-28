import { IInsertRoomType, IRoomType } from "interfaces/IRoomType";
import token from "./token";

const BaseUrl = "http://localhost:5024/api/RoomType";

export async function GetRoomType(): Promise<IRoomType[]> {
    let roomTypes: IRoomType[];
    const response = await fetch(BaseUrl, {
        method: "GET",
        headers:
         {
            'Content-Type': 'application/json',
            'Authorization': token,
        },
    })
    const data = await response.json();
    roomTypes = data.value;
    console.log(roomTypes);
    return roomTypes;
}
export async function GetRoomTypeById(id: number): Promise<IRoomType> {
    let roomType: IRoomType;
    console.log(id);
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: "GET",
        headers:
         {
            'Content-Type': 'application/json',
            'Authorization': token,
        },
    });
     const data = await response.json();
     roomType = data.value;
    console.log(roomType);
    return roomType;
}

export async function AddRoomType(roomTypeFormData: IInsertRoomType): Promise<string> {
    console.log(roomTypeFormData);
    const response = await fetch(`${BaseUrl}`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(roomTypeFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function UpdateRoomType(id: number, roomTypeFormData: IInsertRoomType): Promise<string> {
    console.log(roomTypeFormData);
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: 'Put',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(roomTypeFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function DeleteRoomType(id: number) {
    const response = await fetch(`${BaseUrl}?id=${id}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        }
      });
      const data = await response.json();
      return data.successMessage;
}
