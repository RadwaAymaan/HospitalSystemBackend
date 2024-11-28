"use client";

import { Box, Button, Flex, FormControl, FormLabel, Heading, Input, Link, useColorModeValue } from "@chakra-ui/react";
import { getItemById } from "api/item";
import { getOrderById } from "api/order";
import { IOrder } from "interfaces/IOrder";
import { useEffect, useState } from "react";

export default function GetOrderById({params}: {params: {id: string}}) {
    const [formData, setFormData] = useState<IOrder>({});
    const textColor = useColorModeValue('navy.700', 'white');
    const textColorSecondary = 'gray.400';
    const textColorDetails = useColorModeValue('navy.700', 'secondaryGray.600');
    const textColorBrand = useColorModeValue('brand.500', 'white');
    const brandStars = useColorModeValue('brand.500', 'brand.400');
    const googleBg = useColorModeValue('secondaryGray.300', 'whiteAlpha.200');
    const googleText = useColorModeValue('navy.700', 'white');
    const googleHover = useColorModeValue(
      { bg: 'gray.200' },
      { bg: 'whiteAlpha.300' },
    );
    const googleActive = useColorModeValue(
      { bg: 'secondaryGray.300' },
      { bg: 'whiteAlpha.200' },
    );

    useEffect(() => {
        const fetchOrder = async () => {
            setFormData(await getOrderById(params.id))
        }
        fetchOrder();
    }, []);

    return (
        <Flex
        maxW={{ base: '100%', md: 'max-content' }}
        w="100%"
        mx={{ base: 'auto', lg: '0px' }}
        me="auto"
        h="100%"
        alignItems="start"
        justifyContent="center"
        mb={{ base: '30px', md: '60px' }}
        px={{ base: '25px', md: '0px' }}
        mt={{ base: '40px', md: '14vh' }}
        flexDirection="column"
    >
        <Box me="auto">
          <Heading color={textColor} fontSize="36px" mb="10px">
            Order Details
          </Heading>
        </Box>
        <Flex
          zIndex="2"
          direction="column"
          w={{ base: '100%', md: '420px' }}
          maxW="100%"
          background="transparent"
          borderRadius="15px"
          mx={{ base: 'auto', lg: 'unset' }}
          me="auto"
          mb={{ base: '20px', md: 'auto' }}
        >
          <FormControl>
            <FormLabel
              display="flex"
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              mb="8px"
            >
              ORDER FROM
            </FormLabel>
            <Input
              isRequired={true}
              variant="auth"
              fontSize="sm"
              ms={{ base: '0px', md: '0px' }}
              type="text"
              name="from"
              placeholder="Order From"
              mb="24px"
              fontWeight="500"
              size="lg"
              value={formData.from}
              disabled
            />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              ORDER STATUS
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="orderStatus"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.orderStatus}
                placeholder="Order Status"
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              ORDER DATE
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="text"
                name="orderDate"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.orderDate}
                placeholder="Order Date"
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              display="flex"
            >
              ORDER ARRIVAL DATE
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="text"
                name="orderArrivalDate"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.orderArrivalDate}
                placeholder="Order ArrivalDate"
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Item Name
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="text"
                name="itemName"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.itemOrders && formData.itemOrders.length > 0 ? formData.itemOrders[0]?.item?.name : ''}
                placeholder="Item Name"
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Quantity Requested
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="number"
                name="quantity"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.itemOrders && formData.itemOrders.length > 0 ? formData.itemOrders[0]?.quantity : ''}
                placeholder="Quantity Requested"
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Current Quantity In Stock
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="number"
                name="stock"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.itemOrders && formData.itemOrders.length > 0 ? formData.itemOrders[0]?.item?.stock : ''}
                placeholder="Quantity In Stock"
                disabled
              />
              <Link href="/admin/order">
            <Button
              fontSize="sm"
              variant="brand"
              fontWeight="500"
              w="100%"
              h="50"
              mb="24px"
            >
              Back to Orders
            </Button>
            </Link>
          </FormControl>
        </Flex>
      </Flex>  
    )
}