import { Component } from '@angular/core'
import { FormGroup } from '@angular/forms'
import { InvoicePdfService } from './invoice-pdf.service'
import { InvoicePdfHeaderVM } from './invoice-pdf-header-vm'
import { InvoicePdfPartyTypeVM } from './invoice-pdf-partyType-vm'
import { InvoicePdfSummaryVM } from './invoice-pdf-summary-vm'
import { InvoicePdfAadeVM } from './invoice-pdf-aade-vm'
import { InvoicePdfPortVM } from './invoice-pdf-port-vm'

@Component({
    selector: 'invoice-form',
    templateUrl: './invoice-form.component.html',
})

export class InvoiceFormComponent {

    public form: FormGroup

    constructor(private invoicePdfService: InvoicePdfService) { }

    public onCreatePdf(): void {
        this.createPdfInvoiceParts().then((response) => {
            this.invoicePdfService.createReport(response)
        })
    }

    public async createPdfInvoiceParts(): Promise<any> {
        const header = await this.buildHeader()
        const issuer = await this.buildIssuer()
        const counterPart = await this.buildCounterPart()
        const summary = await this.buildSummary()
        const aade = await this.buildAade()
        const ports = await this.buildPorts()
        const ship = await this.buildShip()
        const paymentMethod = await this.buildPaymentMethod()
        const bankAccounts = await this.buildBankAccounts()
        const balances = await this.buildBalances()
        return {
            header,
            issuer,
            counterPart,
            summary,
            aade,
            ports,
            ship,
            paymentMethod,
            bankAccounts,
            balances
        }
    }

    private buildHeader(): Promise<any> {
        return new Promise((resolve) => {
            const x: InvoicePdfHeaderVM = {
                date: '15/05/2024',
                documentTypeDescription: 'ΤΙΜΟΛΟΓΙΟ ΠΑΡΟΧΗΣ ΥΠΗΡΕΣΙΩΝ',
                batch: 0,
                invoiceNo: '41'
            }
            resolve(x)
        })
    }

    private buildIssuer(): Promise<any> {
        return new Promise((resolve) => {
            const x: InvoicePdfPartyTypeVM = {
                description: 'ΚΕΡΚΥΡΑΙΚΕΣ ΚΡΟΥΑΖΙΕΡΕΣ',
                profession: 'ΝΑΥΤΙΚΗ ΕΤΑΙΡΙΑ',
                phones: '26620 61400',
                email: 'info@corfucruises.com',
                vatNumber: '099999999',
                country: 'GREECE',
                branch: 0,
                taxOffice: 'ΚΕΡΚΥΡΑΣ',
                address: {
                    street: 'KABOS',
                    number: '0',
                    postalCode: '49080',
                    city: 'ΛΕΥΚΙΜΜΗ'
                }
            }
            resolve(x)
        })
    }


    private buildCounterPart(): Promise<any> {
        return new Promise((resolve) => {
            const x: InvoicePdfPartyTypeVM = {
                description: 'AKVILA TRAVEL',
                profession: 'ΓΡΑΦΕΙΟ ΓΕΝΙΚΟΥ ΤΟΥΡΙΣΜΟΥ',
                phones: '26620 99999',
                email: 'akvila@gmail.com',
                vatNumber: '088888888',
                country: 'GREECE',
                branch: 0,
                taxOffice: 'ΚΕΡΚΥΡΑΣ',
                address: {
                    street: 'ΑΓ. ΓΕΩΡΓΙΟΣ - ΑΡΓΥΡΑΔΕΣ',
                    number: '26620 99999',
                    postalCode: '49080',
                    city: 'ΛΕΥΚΙΜΜΗ',
                }
            }
            resolve(x)
        })
    }

    private buildSummary(): Promise<any> {
        return new Promise((resolve) => {
            const x: InvoicePdfSummaryVM = {
                netValue: 1234.56,
                vatAmount: 160.49,
                grossValue: 1395.05,
            }
            resolve(x)
        })

    }

    private buildAade(): Promise<any> {
        return new Promise((resolve) => {
            const x: InvoicePdfAadeVM = {
                uId: '33DA834B40191ACC829FC1A54BF8F3438FE234C0',
                mark: '400001925600940',
                markCancel: '',
                qrUrl: 'https://mydataapidev.aade.gr/TimologioQR/QRInfo?q=CxLHW7Fo2Cx03w9SmhSh7zOw7duCFYONQpjJXJhJcNRhkaqaQNIEtBAeOQKZTx77lfl9PXd768EYGjl5eX%2fJvSWv4EmDrRaHHqvPO%2bRLCQM%3d',
            }
            resolve(x)
        })
    }

    private buildPorts(): Promise<any> {
        const x = []
        return new Promise((resolve) => {
            const z: InvoicePdfPortVM = {
                adultsWithTransfer: 1,
                adultsPriceWithTransfer: 15,
                adultsAmountWithTransfer: 15,
                adultsWithoutTransfer: 2,
                adultsPriceWithoutTransfer: 8,
                adultsAmountWithoutTransfer: 16,
                kidsWithTransfer: 3,
                kidsPriceWithTransfer: 7,
                kidsAmountWithTransfer: 21,
                kidsWithoutTransfer: 2,
                kidsPriceWithoutTransfer: 5,
                kidsAmountWithoutTransfer: 10,
                freeWithTransfer: 6,
                freeWithoutTransfer: 5
            }
            x.push(z)
            const i: InvoicePdfPortVM = {
                adultsWithTransfer: 8,
                adultsPriceWithTransfer: 11,
                adultsAmountWithTransfer: 88,
                adultsWithoutTransfer: 9,
                adultsPriceWithoutTransfer: 12,
                adultsAmountWithoutTransfer: 108,
                kidsWithTransfer: 10,
                kidsPriceWithTransfer: 6,
                kidsAmountWithTransfer: 60,
                kidsWithoutTransfer: 11,
                kidsPriceWithoutTransfer: 5,
                kidsAmountWithoutTransfer: 55,
                freeWithTransfer: 1,
                freeWithoutTransfer: 2
            }
            x.push(i)
            resolve(x)
        })
    }

    private buildShip(): Promise<any> {
        return new Promise((resolve) => {
            const x: string = 'PAXOS STAR'
            resolve(x)
        })
    }

    private buildPaymentMethod(): Promise<any> {
        return new Promise((resolve) => {
            const x: string = 'ΠΙΣΤΩΣΗ'
            resolve(x)
        })
    }

    private buildBalances(): Promise<any> {
        return new Promise((resolve) => {
            const x: number[] = [
                1234.56,
                7890.56
            ]
            resolve(x)
        })
    }
    private buildBankAccounts(): Promise<any> {
        return new Promise((resolve) => {
            const x: string[] = [
                'ΠΕΙΡΑΙΩΣ GR17 0171 1740 0061 7413 5517 925',
                'ALPHA BANK GR41 0140 5950 5950 0233 0002 010',
                'EUROBANK GR53 0260 4450 0003 5020 0621 503',
                'ΕΘΝΙΚΗ GR22 0110 8670 0000 8670 0263 444',
                'ATTICA BANK GR43 0160 8730 0000 0008 5207 750',
                ' '
            ]
            resolve(x)
        })

    }

}
