export interface IPharmacist {
	id: string;
	pharmacistEmail: string;
	pharmacistFirstName: string;
	pharmacistLastName: string;
	pharmacistPhoneNumber: string;
	userName: string;
}
export interface IInsertPharmacist {
	pharmacistEmail: string;
    pharmacistFirstName: string;
	pharmacistLastName: string;
	pharmacistPhoneNumber: string;
	userName: string;
	password: string;
	dateOfBirth: Date;
	gender: string;
}