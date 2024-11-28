"use client";

import { Box, Button, Flex, FormControl, FormLabel, Heading, Input, useColorModeValue } from "@chakra-ui/react";
import { getScheduleById } from "api/schedule";
import { ISchedule } from "interfaces/ISchedule";
import Link from "next/link";
import React from "react";
import { useEffect, useState } from "react";

export default function scheduleDetails({params}: {params: {id: string}}) {
    const [formData, setFormData] = useState<ISchedule>({});
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
        const fetchschedule = async () => {
            setFormData(await getScheduleById (params.id))
        }
        fetchschedule();
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
            schedule Details
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
              DOCTOR ID
            </FormLabel>
            <Input
              isRequired={true}
              variant="auth"
              fontSize="sm"
              ms={{ base: '0px', md: '0px' }}
              type="text"
              name="DoctorId"
              placeholder=" DOCTOR ID"
              mb="24px"
              fontWeight="500"
              size="lg"
              value={formData?.doctorId}
              disabled
            />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              TIMESLOT ID
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="Number"
                name="TimeSlotId"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.timeSlot?.id}
                placeholder="TimeSlot Id"
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              START TIME
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="string"
                name="stock"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.timeSlot?.startTime}
                placeholder="Stock"
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              display="flex"
            >
                END TIME
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="text"
                name="endtime"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.timeSlot?.endTime }
                placeholder="End Time"
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              display="flex"
            >
              DAY
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="text"
                name="Day"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.timeSlot?.day }
                placeholder="DAY"
                disabled
              />
           
             
              <Link href="/admin/schedule">
            <Button
              fontSize="sm"
              variant="brand"
              fontWeight="500"
              w="100%"
              h="50"
              mb="24px"
            >
              Back to schedules
            </Button>
            </Link>
          </FormControl>
        </Flex>
      </Flex>  
    )
}