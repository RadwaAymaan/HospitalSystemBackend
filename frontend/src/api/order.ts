import token from "./token";
import { IOrder } from "interfaces/IOrder";
import { InsertOrder } from "interfaces/InsertOrder";

const BaseUrl = "http://localhost:5024/api/Order";

export async function getOrders(status: string): Promise<IOrder[]> {
    let orders: IOrder[];
    const response = await fetch(`${BaseUrl}/${status}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    orders = data.value;
    console.log(orders);
    return orders;
}

export async function getOrderById(id: string): Promise<IOrder> {
    let order: IOrder;
    console.log(id);
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    order = data.value;
    console.log(order);
    return order;
}

export async function AddOrder(itemOrderFormData: InsertOrder): Promise<string> {
    console.log(itemOrderFormData);
    const response = await fetch(`${BaseUrl}`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(itemOrderFormData)
      });
      const data = await response.json();
      console.log(data);
      return data.successMessage;
}

export async function UpdateOrder(id: number, status: string): Promise<string> {
    const response = await fetch(`${BaseUrl}/orderId/${id}/status/${status}`, {
        method: 'Put',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        }
      });
      const data = await response.json();
      console.log(data);
      return data.successMessage;
}