"use client";

import { getOrders } from "api/order";
import { IOrder } from "interfaces/IOrder";
import { useEffect, useState } from "react";
import OrderColumnTable from "./_component/OrderColumnsTable";
import { Box, Button } from "@chakra-ui/react";

export default function Orders() {
    const [status, setStatus] = useState<string>("Pending");
    const [orders, setOrders] = useState<IOrder[]>([]);

    useEffect(() => {
        const fetchOrders = async () => {
            setOrders(await getOrders(status));
        }
        fetchOrders();
    }, [status])

    const handleStatusChange = (newStatus: string) => {
        setStatus(newStatus);
    };

    console.log("from comp", orders)
    return (
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
            <Button onClick={() => handleStatusChange("Approved")}>Approved</Button>
            <Button onClick={() => handleStatusChange("Pending")}>Pending</Button>
            <Button onClick={() => handleStatusChange("Cancelled")}>Cancelled</Button>
            <OrderColumnTable orders={orders} />
        </Box>
    )
}