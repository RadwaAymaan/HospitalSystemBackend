"use client";

import { Box, Button, Flex, FormControl, FormLabel, Heading, Input, Select } from "@chakra-ui/react";
import { useColorModeValue } from "@chakra-ui/system";
import { UpdateItemCategory, getInventories, getItemCategoryById } from "api/item-category";
import { InsertItemCategory } from "interfaces/InsertItemCategory";
import React, { ChangeEvent, useEffect } from "react";
import { useState } from "react";

export default function UpdateItemC({params}: {params: {id: string}}) {
    const [inventories, setInventories] = useState([]);
    const [formData, setFormData] = useState<InsertItemCategory>({});
    const [message, setMessage] = useState<string>("");
    const [show, setShow] = React.useState(false);
    const handleClick = () => setShow(!show);
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

      },[]);

    useEffect(() => {
        const fetchInventories = async () => {
            let inventories = await getInventories();
            setInventories(inventories);
            console.log("from page", inventories);
          }
          fetchInventories();

        const fetchItem = async () => {
            const itemCategory = await getItemCategoryById(params.id)
            let itemCategoryToUpdate: InsertItemCategory = {
                categoryName: itemCategory.categoryName,
                referenceNumber: itemCategory.referenceNumber,
                inventoryId: null
            };
            setFormData(itemCategoryToUpdate);
        }
        fetchItem();
    }, []);

    const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = e.target;
        setFormData(prevState => ({
          ...prevState,
          [name]: value
        }));
      };

      const handleSubmit = async () => {
        setMessage(await UpdateItemCategory(params.id, formData));
    }

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
            Update Item
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
              Category Name
            </FormLabel>
            <Input
              isRequired={true}
              variant="auth"
              fontSize="sm"
              ms={{ base: '0px', md: '0px' }}
              type="text"
              name="categoryName"
              placeholder="Item Category Name"
              mb="24px"
              fontWeight="500"
              size="lg"
              value={formData.categoryName} 
              onChange={handleChange}
            />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Reference Number
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="referenceNumber"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.referenceNumber} 
                onChange={handleChange} 
                placeholder="Reference Number"
              />
            <FormLabel
            ms="4px"
            fontSize="sm"
            fontWeight="500"
            color={textColor}
            display="flex"
          >
            Inventory
          </FormLabel>
          <Select
            placeholder="Select Inventory"
            onChange={handleChange}
            name="inventoryId"
            mb="24px"
            size="lg"
            variant="auth"
          >
            {inventories.map(inventory => (
              <option key={inventory.id} value={inventory.id}>{inventory.inventoryName}</option>
            ))}
          </Select>
            <Button
              fontSize="sm"
              variant="brand"
              fontWeight="500"
              w="100%"
              h="50"
              mb="24px"
              type="submit"
              onClick={handleSubmit}
            >
              Update Item
            </Button>
          </FormControl>
        </Flex>
        <h1>{message}</h1>
      </Flex> 
      );
}