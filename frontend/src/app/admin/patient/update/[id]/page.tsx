"use client";

import { Box, Button, Checkbox, Flex, FormControl, FormLabel, Heading, Input, Radio } from "@chakra-ui/react";
import { useColorModeValue } from "@chakra-ui/system";
import { getPatientById, updatePatient } from "api/patient";
import { IUpdatePatient } from "interfaces/IPatient";
import React, { ChangeEvent, useEffect } from "react";
import { useState } from "react";

export default function UpdatePatient({ params }: { params: { id: string } }) {
    const [formData, setFormData] = useState<IUpdatePatient>();
    const [message, setMessage] = useState<string>("");
    const textColor = useColorModeValue('navy.700', 'white');

    const fetchEmployee = async () => {
        const patient = await getPatientById(params.id)
        let updatePatient: IUpdatePatient = {
            patientEmail: patient.patientEmail,
            patientFirstName:patient.patientFirstName,
            patientLastName : patient.patientLastName,
            patientPhoneNumber:patient.patientPhoneNumber,
            userName :patient.userName,
            dateOfBirth:patient.dateOfBirth,
            gender:patient.gender
        };
        setFormData(updatePatient);
    }
    useEffect(() => {
        fetchEmployee();
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
        setMessage(await updatePatient(params.id, formData));
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
                    Update Patient
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
                        name="patientEmail"
                        placeholder="Patient Email"
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
                        type="textarea"
                        name="patientFirstName"
                        mb="24px"
                        size="lg"
                        variant="auth"
                        value={formData && formData.patientFirstName}
                        placeholder="Patient First Name"
                        onChange={handleChange}
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
                        placeholder="Patient Last Name"
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
                        placeholder="Date Of Birth"
                        onChange={handleChange}
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
                        placeholder="Phone Number"
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
                        type="text"
                        name="userName"
                        mb="24px"
                        size="lg"
                        variant="auth"
                        value={formData && formData.userName}
                        placeholder="User Name"
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
                        Update Employee
                    </Button>
                </FormControl>
            </Flex>
            <h1>{message}</h1>
        </Flex>
    );
}