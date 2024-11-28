"use client";

import { Box, Button, Flex, FormControl, FormLabel, Heading, Input, useColorModeValue } from "@chakra-ui/react";
import Link from "next/link";
import React from "react";
import { useEffect, useState } from "react";
import { IEmployeeList } from "interfaces/IEmployee";
import { getEmployeeById } from "api/employee";
import { getDepartmentById } from "api/department";
import { IDepartmentList } from "interfaces/IDepartment";

export default function DepartmentDetails({params}: {params: {id: number}}) {
    const [formData, setFormData] = useState<IDepartmentList>();
    const textColor = useColorModeValue('navy.700', 'white');
    
    const fetchDepartment = async () => {
        setFormData(await getDepartmentById(params.id))
    }
    useEffect(() => { 
      fetchDepartment();
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
            Department Details
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
              Name
            </FormLabel>
            <Input
              isRequired={true}
              variant="auth"
              fontSize="sm"
              ms={{ base: '0px', md: '0px' }}
              type="text"
              name="departmentName"
              placeholder="Email"
              mb="24px"
              fontWeight="500"
              size="lg"
              value={formData && formData.departmentName}
              disabled
            />
            
              <Link href="/admin/department">
            <Button
              fontSize="sm"
              variant="brand"
              fontWeight="500"
              w="100%"
              h="50"
              mb="24px"
            >
              Back to Departments
            </Button>
            </Link>
          </FormControl>
        </Flex>
      </Flex>  
    )
}