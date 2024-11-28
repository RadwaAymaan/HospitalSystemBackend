export interface IRoomList {
    id: number,
    roomNumber: number,
    availability: boolean,
    roomType: {
        id: number,
        type: string,
        numberOfPatient: number
    }
}

export interface IRoom {
    roomNumber: number,
    availability: boolean,
    roomTypeId: number
}