import token from "./token";
import { IItemCategory } from "interfaces/IItemCategory";
import { InsertItemCategory } from "interfaces/InsertItemCategory";

const BaseUrl = "http://localhost:5024/api/ItemCategory";

export async function getItemCategories(): Promise<IItemCategory[]> {
    let categories: IItemCategory[];
    const response = await fetch(`${BaseUrl}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    categories = data.value;
    return categories;
}

export async function getItemCategoryById(id: string): Promise<IItemCategory> {
    let category: IItemCategory;
    console.log(id);
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    category = data.value;
    return category;
}

export async function AddItemCategory(itemFormData: InsertItemCategory): Promise<string> {
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

export async function UpdateItemCategory(id: string, itemCategoryFormData: InsertItemCategory): Promise<string> {
    console.log(itemCategoryFormData);
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: 'Put',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(itemCategoryFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function DeleteItemCategory(id: number) {
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

export async function getInventories() {
  const response = await fetch("http://localhost:5024/api/Inventory", {
      method: "GET",
      headers: {
          'Content-Type': 'application/json',
          'Authorization': token
      },
  })
  const data = await response.json();
  console.log(data);
  return data.value;
}