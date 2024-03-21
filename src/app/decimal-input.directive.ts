import { Directive, ElementRef, HostListener, Input, SimpleChange } from '@angular/core'

@Directive({
    selector: '[decimalInput]'
})

export class DecimalInputDirective {

    private element: any

    @Input('decimalInput') format: string

    constructor(private elementRef: ElementRef) {
        this.element = elementRef.nativeElement
    }

    ngOnChanges(changes: { [propName: string]: SimpleChange }): void {
        if (changes['format'] && !changes['format'].isFirstChange() && changes['format'].currentValue !== changes['format'].previousValue) {
            console.log('HERE')
            const value = this.element.nativeElement.value
            this.element.nativeElement.value = parseFloat(value).toFixed(2)
        }
    }

    // @HostListener('focus') onFocus(): any {
    //     const value = this.element.nativeElement.value
    // const length = parseFloat(value).toFixed(3).length
    // this.element.nativeElement.value = parseFloat(value).toFixed(2)
    // this.element.nativeElement.value = parseFloat(value).toFixed(3).substring(0, length - 1)
    // }

    @HostListener('blur') onBlur(): any {
        if (this.element.nativeElement != undefined) {
            const value = this.element.nativeElement.value
            console.log('blur', value)
            const length = parseFloat(value).toFixed(3).length
            this.element.nativeElement.value = parseFloat(value).toFixed(2)
            this.element.nativeElement.value = parseFloat(value).toFixed(3).substring(0, length - 1)
        }
    }

    @HostListener('change') onChange(): any {
        if (this.element.nativeElement != undefined) {
            const value = this.element.nativeElement.value
            console.log('change', value)
            const length = parseFloat(value).toFixed(3).length
            this.element.nativeElement.value = parseFloat(value).toFixed(2)
            this.element.nativeElement.value = parseFloat(value).toFixed(3).substring(0, length - 1)
        }
    }

}
