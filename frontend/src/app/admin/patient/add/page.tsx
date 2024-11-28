'use client';

import {
  Box,
  Button,
  Flex,
  FormControl,
  FormLabel,
  Heading,
  Input,
  Select,
  useColorModeValue,
} from '@chakra-ui/react';
import React, { ChangeEvent, useEffect, useState } from 'react';
import { IPatient } from 'interfaces/IPatient';
import { registerPatient } from 'api/patient';

export default function AddPatient() {
  const [formData, setFormData] = useState<IPatient>();
  const [message, setMessage] = useState<string>('');
  const [show, setShow] = useState(false);
  const textColor = useColorModeValue('navy.700', 'white');

  const handleChange = (
    e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
  ) => {
    const { name, value } = e.target;
    setFormData((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  };

  const handleSubmit = async () => {
    setMessage(await registerPatient(formData));
  };

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
        <Heading color={textColor} fontSize="36px" mb="25px">
          Add Patinet
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
            type="email"
            name="patientEmail"
            placeholder="Pateint Email"
            mb="24px"
            fontWeight="500"
            size="lg"
            value={formData && formData.patientEmail}
            onChange={handleChange}
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
            name="patientFirstName"
            mb="24px"
            size="lg"
            variant="auth"
            value={formData && formData.patientFirstName}
            onChange={handleChange}
            placeholder="Pateint Frist Name"
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
            name="patientLastName"
            mb="24px"
            size="lg"
            variant="auth"
            value={formData && formData.patientLastName}
            onChange={handleChange}
            placeholder="Pateint Last Name"
          />
          <FormLabel
            ms="4px"
            fontSize="sm"
            fontWeight="500"
            color={textColor}
            display="flex"
          >
            Phone Number
          </FormLabel>
          <Input
            isRequired={true}
            fontSize="sm"
            type="tel"
            name="patientPhoneNumber"
            mb="24px"
            size="lg"
            variant="auth"
            value={formData && formData.patientPhoneNumber}
            onChange={handleChange}
            placeholder="Pateint Phone Number"
          />
          
          <FormLabel
            ms="4px"
            fontSize="sm"
            fontWeight="500"
            color={textColor}
            display="flex"
          >
            Gender
          </FormLabel>
          <FormLabel
            ms="4px"
            fontSize="sm"
            fontWeight="500"
            color={textColor}
            display="flex"
          >
            Female
          </FormLabel>
          <input
            required={true}
            // fontSize="sm"
            id="gender"
            type="radio"
            name="gender"
            // mb="24px"

            // variant="auth"
            value="Female"
            placeholder="Gender"
            onChange={handleChange}
          />
          
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Male
            </FormLabel>

            <input
              required={true}
              // fontSize="sm"
              id="gender"
              type="radio"
              name="gender"
              // mb="24px"

              // variant="auth"
              value="Male"
              placeholder="Gender"
              onChange={handleChange}
            />
       
          <FormLabel
            ms="4px"
            fontSize="sm"
            fontWeight="500"
            color={textColor}
            display="flex"
          >
            Date Of Birth
          </FormLabel>
          <Input
            isRequired={true}
            fontSize="sm"
            type="date"
            name="dateOfBirth"
            mb="24px"
            size="lg"
            variant="auth"
            value={formData && formData.dateOfBirth}
            onChange={handleChange}
            placeholder="Date Of Birth"
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
            type="text"
            name="userName"
            mb="24px"
            size="lg"
            variant="auth"
            value={formData && formData.userName}
            onChange={handleChange}
            placeholder="User Name"
          />
          <FormLabel
            ms="4px"
            fontSize="sm"
            fontWeight="500"
            color={textColor}
            display="flex"
          >
            Password
          </FormLabel>
          <Input
            isRequired={true}
            fontSize="sm"
            type="password"
            name="password"
            mb="24px"
            size="lg"
            variant="auth"
            value={formData && formData.password}
            onChange={handleChange}
            placeholder="Password"
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
            Create Pateint
          </Button>
        </FormControl>
      </Flex>
    </Flex>
  );
}
