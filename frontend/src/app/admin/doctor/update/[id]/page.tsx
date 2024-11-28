"use client";

import { Box, Button, Flex, FormControl, FormLabel, Heading, Input } from "@chakra-ui/react";
import { useColorModeValue } from "@chakra-ui/system";
import { UpdateDoctor, getDoctorById } from "api/doctor";
import { IInsertDoctor } from "interfaces/IDoctor";
import React, { ChangeEvent, useEffect } from "react";
import { useState } from "react";

export default function DoctorUpdate({params}: {params: {id: string}}) {
    const [formData, setFormData] = useState<IInsertDoctor>({});
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
        const fetchItem = async () => {
            const item = await getDoctorById(params.id)
            let doctorToUpdate: IInsertDoctor = {
                doctorEmail: item.doctorEmail,
                doctorFirstName:item.doctorFirstName,
                doctorLastName:item.doctorLastName,
                doctorPhoneNumber:item.doctorPhoneNumber,
                userName:item.userName,
                specializationId:item.specialization.id
            };
            setFormData(doctorToUpdate);
        }
        fetchItem();
        
        
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
        setMessage(await UpdateDoctor(params.id, formData));
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
              Doctor Email
            </FormLabel>
            <Input
              isRequired={true}
              variant="auth"
              fontSize="sm"
              ms={{ base: '0px', md: '0px' }}
              type="text"
              name="doctorEmail"
              placeholder="Doctor Email"
              mb="24px"
              fontWeight="500"
              size="lg"
              value={formData.doctorEmail}
              onChange={handleChange} 
            />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Doctor First Name
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="doctorFirstName"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.doctorFirstName}
                placeholder="Doctor First Name"
                onChange={handleChange} 
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Doctor Last Name
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="doctorLastName"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.doctorLastName}
                placeholder="Doctor Last Name"
                onChange={handleChange} 
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              display="flex"
            >
              Doctor Phone Number
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="doctorPhoneNumber"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.doctorPhoneNumber}
                placeholder="doctorPhoneNumber"
                onChange={handleChange} 
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
                value={formData.userName}
                placeholder="User Name"
                onChange={handleChange} 
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Specialization Name
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="number"
                name="categoryId"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.specializationId}
                placeholder="Specialization Name"
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
              Update Item
            </Button>
          </FormControl>
        </Flex>
        <h1>{message}</h1>
      </Flex> 
      );
}