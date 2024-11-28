"use client";

import { Box, Button, Flex, FormControl, FormLabel, Heading, Input, Select, useColorModeValue } from "@chakra-ui/react"
import { title } from "process";
import React from "react";
import { ChangeEvent, useEffect, useState } from "react";

export interface IFieldsProps {
    disabled: boolean,
    heading: string,
    title:string,
    fields: Array<{label: string, name: string, inputType: string, placeholder: string}>,
    data?: any,
    dropDownList?: {label: string, name: string, placeholder: string, value: string, displayName: string, data: Array<any>},
    onSubmit: (formData: any) => void,
    
   
  }

  const CompactForm = ({heading,title, fields, data, dropDownList, disabled, onSubmit}: IFieldsProps) => {
    const [formData, setFormData] = useState<any>({});
    const textColor = useColorModeValue('navy.700', 'white');

    const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = e.target;
        setFormData((prevState: any) => ({
          ...prevState,
          [name]: value
        }));
    };

    useEffect(() => {
      if(data) {
          setFormData(data);
          console.log(formData);
      }
    }, [data]);


    const handleSubmit = async () => {
        onSubmit(formData);
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
           {title}
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
          {fields.map(field => (
                        <React.Fragment key={field.name}>
                            <FormLabel
                                display="flex"
                                ms="4px"
                                fontSize="sm"
                                fontWeight="500"
                                color={textColor}
                                mb="8px"
                            >
                                {field.label}
                            </FormLabel>
                            <Input
                                isRequired={true}
                                variant="auth"
                                fontSize="sm"
                                ms={{ base: '0px', md: '0px' }}
                                type={field.inputType}
                                name={field.name}
                                placeholder={field.placeholder}
                                mb="24px"
                                fontWeight="500"
                                size="lg"
                                value={formData[field.name] || ''}
                                onChange={handleChange}
                                isDisabled={disabled}
                            />
                        </React.Fragment>
                    ))}
                    {dropDownList && (
                        <React.Fragment>
                            <FormLabel
                                ms="4px"
                                fontSize="sm"
                                fontWeight="500"
                                color={textColor}
                                display="flex"
                            >
                                {dropDownList.label}
                            </FormLabel>
                            <Select
                                placeholder={dropDownList.placeholder}
                                onChange={handleChange}
                                name={dropDownList.name}
                                mb="24px"
                                size="lg"
                                variant="auth"
                            >
                                {dropDownList.data.map(option => (
                                    <option key={option[dropDownList.value]} value={option[dropDownList.value]}>{option[dropDownList.displayName]}</option>
                                ))}
                            </Select>
                        </React.Fragment>
                    )}
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
              {heading}
            </Button>
          </FormControl>
        </Flex>
      </Flex>  
    )
  }

  export default CompactForm;