export interface InvoicePdfPartyTypeVM {

    description: string
    vatNumber: string
    branch: number
    profession: string
    address: InvoicePdfAddressVM
    country: string
    taxOffice: string
    phones: string
    email: string

}

export interface InvoicePdfAddressVM {
    street: string
    number: string
    postalCode: string
    city: string

}
