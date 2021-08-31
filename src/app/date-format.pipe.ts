import { formatDate } from '@angular/common'
import { Pipe, PipeTransform } from '@angular/core'

@Pipe({ name: 'dateFormat' })

export class DateFormat implements PipeTransform {

    private key = 'el-GR'
    private locale = 'en-US'

    transform(date: string | number | Date): string {
        switch (this.key) {
            case 'de-DE':
                return formatDate(date, 'dd.MM.yyyy', this.locale)
            case 'el-GR':
                return formatDate(date, 'dd/MM/yyyy', this.locale)
            case 'en-GB':
                return formatDate(date, 'dd/MM/yyyy', this.locale)
            case 'fr-FR':
                return formatDate(date, 'dd/MM/yyyy', this.locale)
            case 'cs-CZ':
                return formatDate(date, 'dd. MM. yyyy', this.locale)
            default: break
        }

    }

}
