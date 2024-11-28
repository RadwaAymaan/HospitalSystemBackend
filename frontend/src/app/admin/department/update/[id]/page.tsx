"use client";

import { Box, Button, Checkbox, Flex, FormControl, FormLabel, Heading, Input } from "@chakra-ui/react";
import { useColorModeValue } from "@chakra-ui/system";
import { getDepartmentById, updateDepartment } from "api/department";
import { IDepartment } from "interfaces/IDepartment";
import React, { ChangeEvent, useEffect } from "react";
import { useState } from "react";

export default function UpdateDepartment({ params }: { params: { id: number } }) {
    const [formData, setFormData] = useState<IDepartment>();
    const [message, setMessage] = useState<string>("");
    const textColor = useColorModeValue('navy.700', 'white');

    const fetchDepartment = async () => {
        const dept = await getDepartmentById(params.id)
        let updateDepartment: IDepartment = {
            departmentName: dept.departmentName,
        };
        setFormData(updateDepartment);
    }
    useEffect(() => {  
        fetchDepartment();
    }, []);

    const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        console.log(formData);
        const { name, value } = e.target;
        setFormData(prevState => ({
            ...prevState,
            [name]: value
        }));
    };

    const handleSubmit = async () => {
        setMessage(await updateDepartment(params.id, formData));
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
                    Update Doctor
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
                        Department Name
                    </FormLabel>
                    <Input
                        isRequired={true}
                        variant="auth"
                        fontSize="sm"
                        ms={{ base: '0px', md: '0px' }}
                        type="text"
                        name="departmentName"
                        placeholder="Department Name"
                        mb="24px"
                        fontWeight="500"
                        size="lg"
                        value={formData && formData.departmentName}
                        onChange={handleChange}
                    /> 
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
                        Update Department
                    </Button>
                </FormControl>
            </Flex>
            <h1>{message}</h1>
        </Flex>
    );
}