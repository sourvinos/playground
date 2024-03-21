import { formatNumber } from '@angular/common'
import { Directive, ElementRef, EventEmitter, forwardRef, HostListener, Input, Output } from '@angular/core'
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms'
import { MAT_INPUT_VALUE_ACCESSOR } from '@angular/material/input'

@Directive({
    selector: 'input[localizedNumericInput]',
    providers: [
        { provide: MAT_INPUT_VALUE_ACCESSOR, useExisting: LocalizedNumericInputDirective },
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: forwardRef(() => LocalizedNumericInputDirective),
            multi: true
        }
    ]
})

export class LocalizedNumericInputDirective implements ControlValueAccessor {

    locale = 'en'
    decimalMarker: string

    constructor(private element: ElementRef<HTMLInputElement>) { }

    private _value: string | null

    get value(): string | null {
        return this._value
    }

    @Input('value')
    set value(value: string | null) {
        this._value = value
        this.formatValue(value)
    }

    @Input('localizedNumericInput') set valor(valor: number) {
        if (!valor) { valor = 0 }
        this.formatValue(valor.toString())
    }
    @Output('localizedNumericInputChange') valorChange = new EventEmitter<number>()


    @Input('objeto') objeto: any
    @Input('propiedad') propiedad: string

    @HostListener('input', ['$event.target.value'])

    input(value): void {
        //Find all numerics, decimal marker(, or .) and -
        //It will delete thousandSeparator cos it's always opposite to decimal marker
        const regExp = new RegExp(`[^\\d${this.decimalMarker}-]`, 'g')
        //Separate value on before and after decimal marker
        let [integer, decimal] = value.replace(regExp, '').split(this.decimalMarker)

        if (!integer) { integer = 0 }
        if (!decimal) { decimal = 0 }

        //Send non localized value, with dot as decimalMarker to API
        this._value = decimal ? integer.concat('.', decimal) : integer

        // If decimal separator is last character don't update
        // because it will delete . || ,
        if (this.isLastCharacterDecimalSeparator(value)) {
            this._value = value
        }

        // here to notify Angular Validators
        this._onChange(this._value)
    }

    @HostListener('blur')
    _onBlur(): void {
        /**
         * Adding thousand separators
         */
        this.formatValue(this._value)
        this.valorChange.emit(parseFloat(this._value))
    }

    @HostListener('focus')
    onFocus(): void {
        this.unFormatValue()
    }

    _onChange(value: any): void {
        console.log(value)
    }

    /**
     * @param value
     * apply formatting on value assignment
     */
    writeValue(value: any): void {
        this._value = value
        this.formatValue(this._value)
    }

    registerOnChange(fn: (value: any) => void): void {
        this._onChange = fn
    }

    registerOnTouched(): void { }

    isLastCharacterDecimalSeparator(value: any): boolean {
        return isNaN(value[value.length - 1])
    }

    private formatValue(value: string | null): void {
        if (value === null) {
            this.element.nativeElement.value = ''
            return
        }

        if (this.isLastCharacterDecimalSeparator(value.toString())) {
            this.element.nativeElement.value = value
            return
        }

        // Conclude the decimal and thousand separators from locale
        const [thousandSeparator, decimalMarker] = formatNumber(1000.99, this.locale).replace(/\d/g, '')
        this.decimalMarker = decimalMarker

        //Here value should always come with . as decimal marker thus any other behavior is bug
        let [integer, decimal] = value.toString().split('.')
        // let [integer, decimal] = value.toString().split(this.decimalMarker)

        if (!integer) { integer = '0' }
        if (!decimal) { decimal = '00' }

        //Group every three elements, and add thousandSeparator after them
        this.element.nativeElement.value = integer.replace(/\B(?=(\d{3})+(?!\d))/g, thousandSeparator)

        //Add decimals and decimalMarker if any
        if (decimal) {
            this.element.nativeElement.value = this.element.nativeElement.value.concat(decimalMarker, decimal)
        }
    }

    private unFormatValue(): void {
        const value = this.element.nativeElement.value

        if (this.isLastCharacterDecimalSeparator(value)) {
            return
        }

        const regExp = new RegExp(`[^\\d${this.decimalMarker}-]`, 'g')
        let [integer, decimal] = value.replace(regExp, '').split(this.decimalMarker)

        if (!integer) { integer = '0' }
        if (!decimal) { decimal = '00' }

        this._value = integer.concat('.', decimal)
        if (value) {
            this.element.nativeElement.value = this._value
        } else {
            this.element.nativeElement.value = ''
        }
    }
}
