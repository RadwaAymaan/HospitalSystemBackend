"use client";

import { Box, Button, Flex, FormControl, FormLabel, Heading, Input, useColorModeValue } from "@chakra-ui/react";
import Link from "next/link";
import React from "react";
import { useEffect, useState } from "react";
import { IEmployeeList } from "interfaces/IEmployee";
import { GetByIdEmployee } from "api/employee";



export default function EmployeeDetails({params}: {params: {id: string}}) {
    const [formData, setFormData] = useState<IEmployeeList>();
    const textColor = useColorModeValue('navy.700', 'white');
    
    const fetchItem = async () => {
        setFormData(await GetByIdEmployee(params.id))
    }
    useEffect(() => { 
      fetchItem();
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
            Employee Details
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
              Email
            </FormLabel>
            <Input
              isRequired={true}
              variant="auth"
              fontSize="sm"
              ms={{ base: '0px', md: '0px' }}
              type="text"
              name="employeeEmail"
              placeholder="Email"
              mb="24px"
              fontWeight="500"
              size="lg"
              value={formData && formData.employeeEmail}
              disabled
            />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
               First Name
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="text"
                name="employeeFirstName"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData && formData.employeeFirstName}
                placeholder="First Name"
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
             Last Name
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="text"
                name="employeeLastName"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData && formData.employeeLastName}
                placeholder="Last Name"
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              display="flex"
            >
            Phone Number
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="tel"
                name="employeePhoneNumber"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData && formData.employeePhoneNumber}
                placeholder="Phone Number"
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              User Name
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="userName"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData && formData.userName}
                placeholder="User Name"
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Department Name
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="departmentName"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData && formData.department?.departmentName}
                placeholder="Department Name"
                disabled
              />
              <Link href="/admin/employee">
            <Button
              fontSize="sm"
              variant="brand"
              fontWeight="500"
              w="100%"
              h="50"
              mb="24px"
            >
              Back to Employees
            </Button>
            </Link>
          </FormControl>
        </Flex>
      </Flex>  
    )
}