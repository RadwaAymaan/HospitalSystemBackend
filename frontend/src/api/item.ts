import { IItem } from "interfaces/IItem";
import token from "./token";
import { InsertItem } from "interfaces/InsertItem";

const BaseUrl = "http://localhost:5024/api/Item";

export async function getItems(): Promise<IItem[]> {
    let items: IItem[];
    const response = await fetch(`${BaseUrl}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    items = data.value;
    console.log(items);
    return items;
}

export async function getItemById(id: string): Promise<IItem> {
    let item: IItem;
    console.log(id);
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    item = data.value;
    console.log(item);
    return item;
}

export async function AddItem(itemFormData: InsertItem): Promise<string> {
    console.log(itemFormData);
    const response = await fetch(`${BaseUrl}`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(itemFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function UpdateItem(id: string, itemFormData: InsertItem): Promise<string> {
    console.log(itemFormData);
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: 'Put',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(itemFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function DeleteItem(id: number) {
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        }
      });
      const data = await response.json();
      return data.successMessage;
}